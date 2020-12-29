using System.Collections.Generic;
using System.Linq;
using WebShop.DAL.Interfaces;
using WebShop.Models;

namespace WebShop.BLL.Cart
{
    [Service]
    public class GetOrder
    {
        private readonly ISessionManager session;

        public GetOrder(ISessionManager session)
        {
            this.session = session;
        }


        public class ProductOrderResp
        {
            public IEnumerable<ProductOrder> Products { get; set; }
            public CustomerInfo CustomerInformation { get; set; }

            public int GetTotalPrice() => Products.Sum(product => product.Price * product.Quantity);

        }

        public ProductOrderResp DoReturnCart()
        {

            var products = session
                .GetCart(product => new ProductOrder
                {
                    StockId = product.StockId,
                    ProductId = product.ProductId,
                    Price = int.Parse(product.Price),
                    Quantity = product.Quantity,
                });

            var customerInformation = session.GetCustomerInfo();

            return new ProductOrderResp
            {
                Products = products,
                CustomerInformation = new CustomerInfo
                {
                    FirstName = customerInformation.FirstName,
                    LastName = customerInformation.LastName,
                    Email = customerInformation.Email,
                    PhoneNumber = customerInformation.PhoneNumber,
                    Address = customerInformation.Address,
                    City = customerInformation.City,
                    PostCode = customerInformation.PostCode
                }
            };
        }
    }
}