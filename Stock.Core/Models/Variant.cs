using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Stock.Core.Models
{
    public class Variant
    {
        public Variant()
        {
            Stocks = new Collection<StockInfo>();
        }
        public int Id { get; set; }
        public string VariantCode { get; set; }
        public int ProductId{ get; set; }
        public Product Product { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public ICollection<StockInfo> Stocks { get; set; }

    }
}

