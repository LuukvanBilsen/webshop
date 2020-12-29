using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Models
{
    public class StocksFromProduct
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
    }
}
