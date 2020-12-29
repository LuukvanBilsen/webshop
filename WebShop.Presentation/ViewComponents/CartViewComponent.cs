using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.BLL.Cart;
using WebShop.DAL;

namespace WebShop.Presentation.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private GetCart getCart;

        public CartViewComponent( GetCart getCart)
        {
            this.getCart = getCart;
        }

        public IViewComponentResult Invoke(string view = "Default")
        {

            return View(view, getCart.DoReturnCart());
        }
    }
}
