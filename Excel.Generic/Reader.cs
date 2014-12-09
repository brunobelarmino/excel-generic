using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Excel.Generic.Attribute;
using Excel.Generic.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Excel.Generic
{
    public class Reader
    {
        /// <summary>
        /// Método para leitura de Excel.
        /// </summary>
        /// <typeparam name="T">Tipo que deseja popular com dados do excel.</typeparam>
        /// <param name="stream">Stream do excel.</param>
        /// <param name="validateSchema">(Método/Expressão Lambda) para validação do excel. O método recebe como parâmetro uma lista de strings com o nome de todas as colunas do excel.</param>
        /// <returns>Uma lista contendo de objetos populados com os dados do excel.</returns>
        public static List<T> Read<T>(Stream stream, Action<List<string>> validateSchema) where T : class, new()
        {
            try
            {
                using (var spreedsheet = SpreadsheetDocument.Open(stream, false))
                {
                    WorksheetPart worksheet = spreedsheet.WorkbookPart.WorksheetParts.First();
                    SharedStringTable sharedStringTable = spreedsheet.WorkbookPart.SharedStringTablePart.SharedStringTable;
                    Dictionary<string, string> columns = new Dictionary<string, string>();
                    List<T> items = new List<T>();

                    bool firstLine = true;

                    using (var reader = OpenXmlReader.Create(worksheet))
                    {
                        while (reader.Read())
                        {
                            if (reader.ElementType == typeof(Row))
                            {
                                T item = Activator.CreateInstance<T>();

                                reader.ReadFirstChild();

                                do
                                {
                                    if (reader.ElementType == typeof(Cell))
                                    {
                                        Cell cell = (Cell)reader.LoadCurrentElement();
                                        string cellReference = cell.CellReference.Value.Substring(0, 1);
                                        string value = GetCellValue(sharedStringTable, cell);

                                        if (firstLine)
                                        {
                                            columns.Add(cellReference, value);
                                            continue;
                                        }

                                        SetPropertyValue(item, value, columns[cellReference]);
                                    }
                                }
                                while (reader.ReadNextSibling());

                                if (firstLine && validateSchema != null) validateSchema(columns.Values.ToList());
                                if (!firstLine) items.Add(item);

                                firstLine = false;
                            }
                        }
                    }

                    return items;
                }
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Ocorreu um erro no processamento do arquivo excel.");
            }
        }

        /// <summary>
        /// Método para leitura de Excel.
        /// </summary>
        /// <typeparam name="T">Tipo que deseja popular com dados do excel.</typeparam>
        /// <param name="stream">Stream do excel.</param>
        /// <returns>Uma lista contendo de objetos populados com os dados do excel.</returns>
        public static List<T> Read<T>(Stream stream) where T : class, new()
        {
            return Read<T>(stream, null);
        }

        private static void SetPropertyValue<T>(T item, string value, string column) where T : class
        {
            Type attributeType = typeof(ExcelAttribute);

            PropertyInfo property = item.GetType().GetProperties().Where(prop => System.Attribute.IsDefined(prop, attributeType)
                && ((ExcelAttribute)System.Attribute.GetCustomAttribute(prop, attributeType)).Column.Equals(column)).FirstOrDefault();

            if (property != null)
            {
                property.SetValue(item: item, value: value);
            }
        }

        private static string GetCellValue(SharedStringTable sharedStringTable, Cell cell)
        {
            if (cell.CellValue == null)
                return string.Empty;

            string value = cell.CellValue.InnerXml;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return sharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }
    }
}
