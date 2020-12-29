using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Models.DALModels;

namespace WebShop.Models.DALModels
{
    public class OrderStocks
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Quantity { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
