using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Models.DALModels
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderRef { get; set; }
        public string StripeRef { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public ICollection<OrderStocks> OrderStocks { get; set; }
    }
}
