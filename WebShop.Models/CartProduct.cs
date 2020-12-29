using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Models
{
    public class CartProduct
    {
        //product thru stockId
        public int ProductId { get; set; }
        public int StockId { get; set; }
        public int Quantity { get; set; }
    }
}
