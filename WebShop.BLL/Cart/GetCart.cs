using System.Collections.Generic;
using WebShop.Models;
using WebShop.DAL.Interfaces;
using System;

namespace WebShop.BLL.Cart
{
    [Service]
    public class GetCart
    {
        private readonly ISessionManager session;

        public GetCart(ISessionManager session)
        {
            this.session = session;
        }

        public IEnumerable<CartProductView> DoReturnCart()
        {
            return session
                .GetCart(x => new CartProductView
                {
                    Name = x.Name,
                    Price = (Int32.Parse(x.Price) / 100).ToString("N2"),
                    StockId = x.StockId,
                    Quantity = x.Quantity,
                });
        }
    }
}