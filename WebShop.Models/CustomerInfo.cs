using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Models
{
    public class CustomerInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}
