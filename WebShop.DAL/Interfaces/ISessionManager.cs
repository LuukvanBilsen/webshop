using WebShop.Models;
using System.Collections.Generic;
using System;

namespace WebShop.DAL.Interfaces
{
    
    public interface ISessionManager
    {
        string GetId();
        void AddProduct(CartProductView cartProduct);
        void RemoveProduct(int StockId, int Quantity);
        IEnumerable<TResult> GetCart<TResult>(Func<CartProductView, TResult> selector);

        void AddCustomerInformation(CustomerInfo customer);
        CustomerInfo GetCustomerInfo();
    }
}