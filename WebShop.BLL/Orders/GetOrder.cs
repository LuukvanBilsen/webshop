using System.Collections.Generic;
using System.Linq;
using WebShop.DAL.Interfaces;

namespace WebShop.BLL.Order
{
    [Service]
    public class GetOrder
    {
        private IOrderManager orderManager;

        public GetOrder(IOrderManager orderManager)
        {
            this.orderManager = orderManager;
        }

        public OrderDetails DoGetOrder(string reference)
        {
            return orderManager.GetOrderByReference(reference, details => new OrderDetails
            {
                OrderRef = details.OrderRef,

                FirstName = details.FirstName,
                LastName = details.LastName,
                Email = details.Email,
                PhoneNumber = details.PhoneNumber,
                Address = details.Address,
                City = details.City,
                PostCode = details.PostCode,

                Products = details.OrderStocks.Select(x => new Product
                {
                    Name = x.Stock.Product.Name,
                    Description = x.Stock.Product.Description,
                    Price = x.Stock.Product.Price,

                    Quantity = x.Quantity,
                    StockDescription = x.Stock.Description
                }),
                TotalPrice = details.OrderStocks.Sum(y => y.Stock.Product.Price).ToString()
            });
        }

        public class OrderDetails
        {
            public string OrderRef { get; set; }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public string Address { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }

            public IEnumerable<Product> Products { get; set; }

            public string TotalPrice { get; set; }
        }

        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public int Quantity { get; set; }
            public string StockDescription { get; set; }
        }
    }
}
