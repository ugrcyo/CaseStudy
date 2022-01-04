using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Stock.Core.Models
{
    public class Size
    {
        public Size()
        {
            Variants = new Collection<Variant>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Variant> Variants { get; set; }

    }
}
