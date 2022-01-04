using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock.Core.Models
{
    public class StockInfo
    {     
        public int Id { get; set; }
        public int VariantId{ get; set; }
        public Variant Variant { get; set; }
        public int ProductId  { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
