using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Models
{
    public class ProductWithStock
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IEnumerable<StocksFromProduct> Stock { get; set; }
    }
}
