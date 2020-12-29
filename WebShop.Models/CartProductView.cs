using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Models
{
    public class CartProductView
    {
        //product thru stock
        public int ProductId { get; set; }

        public string Name { get; set; }
        public string Price { get; set; }

        public int StockId { get; set; }
        public int Quantity { get; set; }
    }
}
