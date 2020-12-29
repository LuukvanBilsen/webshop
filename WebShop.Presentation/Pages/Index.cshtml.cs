using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop.BLL.Products;
using WebShop.BLL.ProductsAdmin;
using WebShop.BLL.ViewModels;
using WebShop.DAL;

namespace WebShop.Presentation.Pages
{
    public class IndexModel : PageModel
    {
        private AppDBContext dBContext;
        

        public IndexModel(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
  
        }   
   

        //wat we binden is main model "product"   
        //niet via DAL direct

        //[BindProperty]      
        //public ProductViewModel Product { get; set; }

        public IEnumerable<ProductViewModel> AllProducts { get; set; }

        public void OnGet([FromServices] GetProducts getProducts)
        {
            AllProducts = getProducts.DoGetProducts();
        }

    //public async Task<IActionResult> OnPost()
    //{
    //    await new CreateProducts(_dBcontext).DoCreateProduct(Product);
    //    //redirectaction = controller, redirecttopage = razorpage
    //    return RedirectToPage("index");
    //}
}
}
