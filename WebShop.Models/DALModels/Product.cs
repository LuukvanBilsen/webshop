 using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Models.DALModels;

namespace WebShop.Models.DALModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public ICollection<Stock> Stocks {get; set;}
        //public ICollection<OrderProductLink> OrderProductLink { get; set; }

    }
}
