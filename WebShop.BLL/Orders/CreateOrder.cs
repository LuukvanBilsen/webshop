using System;
using System.Linq;
using System.Threading.Tasks;
using WebShop.BLL.ViewModels;
using WebShop.DAL.Interfaces;
using WebShop.Models.DALModels;

namespace WebShop.BLL
{
    [Service]
    public class CreateOrder
    {
        private IOrderManager orderManager;
        private IStockManager stockManager;

        public CreateOrder(IOrderManager orderManager, IStockManager stockManager)
        {
            this.orderManager = orderManager;
            this.stockManager = stockManager;
        }

        public class Stock
        {
            public int StockId { get; set; }
            public int Quantity { get; set; }
        }

        public async Task<bool> DoCreateOrder(StripeDetails details)
        {

            var order = new Models.DALModels.Order
            {
                StripeRef = details.StripeReference,
                OrderRef = CreateRef(),

                FirstName = details.FirstName,
                LastName = details.LastName,
                Email = details.Email,
                PhoneNumber = details.PhoneNumber,
                Address = details.Address,
                City = details.City,
                PostCode = details.PostCode,

                OrderStocks = details.Stocks.Select(x => new OrderStocks
                {
                    StockId = x.StockId,
                    Quantity = x.Quantity,
                }).ToList()
            };

            var succes = await orderManager.CreateOrder(order) > 0;
            return succes;
        }

        public string CreateRef()
        {
            var chars = "QWERTYUIOPASDFGHJKLZXCVBNMmnbvcxzlkjhgfdsapoiuytrewq0123456789";
            var result = new char[12];
            var rnd = new Random();

            do
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = chars[rnd.Next(chars.Length)];
                }
            }
            while (orderManager.OrderReferenceExists(new string(result)));

            return new string(result);
        }
    }
}
