using Excel.Generic.Attribute;
using System;

namespace WebApp.Model
{
    public class Product
    {
        [Excel(Column = "Codigo")]
        public string Sku { get; set; }

        [Excel(Column = "Quantidade")]
        public decimal Qtd { get; set; }

        [Excel(Column = "Data Entrega Limite")]
        public DateTime FirstDate { get; set; }

        [Excel(Column = "Data Entrega Prevista")]
        public DateTime LastDate { get; set; }
    }
}
