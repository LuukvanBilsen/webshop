using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.DAL.Interfaces;
using WebShop.Models.DALModels;

namespace WebShop.DAL.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly AppDBContext context;

        public OrderManager(AppDBContext context)
        {
            this.context = context;
        }


        public Task<int> CreateOrder(Order order)
        {
            context.Order.Add(order);

            return context.SaveChangesAsync();
        }

        public TResult GetOrderByReference<TResult>(string reference, Func<Order, TResult> selector)
        {
            return context.Order
                .Where(x => x.OrderRef == reference)
                .Include(x => x.OrderStocks)
                .ThenInclude(x => x.Stock)
                .ThenInclude(x => x.Product)
                .Select(selector)
                .FirstOrDefault();
        }

        public bool OrderReferenceExists(string reference)
        {
            return context.Order.Any(x => x.OrderRef == reference);
        }
    }
}
