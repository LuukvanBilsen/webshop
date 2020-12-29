using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Models.DALModels;

namespace WebShop.Models.DALModels
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<OrderStocks> OrderStocks { get; set; }
    }
}
