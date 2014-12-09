using Excel.Generic.Test.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Excel.Generic.Test
{
    [TestFixture]
    public class ReaderTest
    {
        [Test]
        public void Read()
        {
            string FILE_PATH = Path.GetFullPath("./Files/Excel.xlsx");
            IEnumerable<Product> products = Enumerable.Empty<Product>();

            using (var file = File.OpenRead(FILE_PATH))
            {
                products = Reader.Read<Product>(file);
            }

            CollectionAssert.IsNotEmpty(products);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ValidateAndRead()
        {
            string FILE_PATH = Path.GetFullPath("./Files/Excel.xlsx");

            using (var file = File.OpenRead(FILE_PATH))
            {
                Reader.Read<Product>(file, columns =>
                {
                    if (columns.Count < 5)
                    {
                        throw new Exception();
                    }
                
                });
            }
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void ReadWithBlankLines()
        {
            string FILE_PATH = Path.GetFullPath("./Files/ExcelWithBlankLines.xlsx");

            using (var file = File.OpenRead(FILE_PATH))
            {
                Reader.Read<Product>(file);
            }
        }
    }
}
