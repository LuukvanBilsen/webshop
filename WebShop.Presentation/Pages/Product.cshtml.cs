using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop.BLL.Cart;
using WebShop.BLL.Products;
using WebShop.DAL;
using WebShop.Models;

namespace WebShop.Presentation
{
    public class ProductModel : PageModel
    {
        private AppDBContext context;

        public ProductModel(AppDBContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public CartProduct CartView {get; set;}

        public ProductWithStock Product { get; set; }
   
        public IActionResult OnGet(string name, [FromServices] GetProduct getProduct)
        {
            Product = getProduct.DoGetProduct(name.Replace("-", " "));
            if (Product == null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost([FromServices] AddToCart addToCart)
        {
            //new AddToCart(HttpContext.Session).DoAddToCart(CartView);
            addToCart.DoAddToCart(CartView);

            return RedirectToPage("Cart");
        }
    }
}