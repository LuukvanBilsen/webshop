using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop.BLL.Cart;
using WebShop.DAL;
using WebShop.Models;

namespace WebShop.Presentation
{
    public class CartModel : PageModel
    {
        public IEnumerable<CartProductView> Cart {get; set;}

        public IActionResult OnGet([FromServices] GetCart getCart)
        {
            Cart = getCart.DoReturnCart();

            return Page();
        }
    }
}