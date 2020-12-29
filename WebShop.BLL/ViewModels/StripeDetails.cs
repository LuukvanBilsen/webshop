using System.Collections.Generic;
using static WebShop.BLL.CreateOrder;

namespace WebShop.BLL.ViewModels
{
    public class StripeDetails
    {
        public string StripeReference { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public List<Stock> Stocks { get; set; }
    }
}
