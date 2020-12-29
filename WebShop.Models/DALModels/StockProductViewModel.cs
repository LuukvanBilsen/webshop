using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Models.DALModels
{
    public class StockProductViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<Stock> Stock { get; set; }
    }
}
