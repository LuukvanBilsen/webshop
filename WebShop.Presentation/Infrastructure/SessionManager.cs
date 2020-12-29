using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.DAL.Interfaces;
using WebShop.Models;

namespace WebShop.Presentation.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private ISession session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            this.session = httpContextAccessor.HttpContext.Session;
        }

        public void AddCustomerInformation(CustomerInfo customer)
        {

            var stringOfCartProduct = JsonConvert.SerializeObject(customer);

            session.SetString("customer-info", stringOfCartProduct);
        }

        public void AddProduct(CartProductView cartProduct)
        {

            var cart = new List<CartProductView>(); 
            var stringOfCartProduct = session.GetString("cart");          
            
            if (!string.IsNullOrEmpty(stringOfCartProduct))
            {
                cart = JsonConvert.DeserializeObject<List<CartProductView>>(stringOfCartProduct);
            }

            //Check if item is already in cart, if so append 
            if (cart.Any(itemInCart => itemInCart.StockId == cartProduct.StockId))
            {
                cart.Find(itemInCart => itemInCart.StockId == cartProduct.StockId).Quantity += cartProduct.Quantity;
            }
            else
            {
                cart.Add(cartProduct);
            }

            stringOfCartProduct = JsonConvert.SerializeObject(cart);            
            session.SetString("cart", stringOfCartProduct);
        }

        public IEnumerable<TResult> GetCart<TResult>(Func<CartProductView, TResult> selector)
        {
            var stringOfCartProduct = session.GetString("cart");
            if (string.IsNullOrEmpty(stringOfCartProduct))
            {
                return new List<TResult>();
            }

            var cart = JsonConvert.DeserializeObject<IEnumerable<CartProductView>>(stringOfCartProduct);
            return cart.Select(selector);

        }

        public CustomerInfo GetCustomerInfo()
        {
            var CustomerInfo = session.GetString("customer-info");

            if (string.IsNullOrEmpty(CustomerInfo))
            {
                return null;
            }

            var ConvertedCustomerInfo = JsonConvert.DeserializeObject<CustomerInfo>(CustomerInfo);

            return ConvertedCustomerInfo;
        }

        public string GetId() => session.Id;

        public void RemoveProduct(int StockId, int Quantity)
        {
            throw new NotImplementedException();
        }
    }
}
