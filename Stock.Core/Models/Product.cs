using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Stock.Core.Models
{
    public class Product
    {
        public Product()
        {
            Stocks = new Collection<StockInfo>();
            Variants = new Collection<Variant>();

        }
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<StockInfo> Stocks { get; set; }
        public ICollection<Variant> Variants { get; set; }

    }
}