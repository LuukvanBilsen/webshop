using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Models.DALModels;

namespace WebShop.DAL.Interfaces
{
    public interface IOrderManager
    {
        TResult GetOrderByReference<TResult>(string reference, Func<Order, TResult> selector);

        bool OrderReferenceExists(string reference);
        Task<int> CreateOrder(Order order); //
    }
}
