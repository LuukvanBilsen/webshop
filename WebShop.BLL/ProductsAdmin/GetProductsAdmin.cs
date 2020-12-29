using System.Collections.Generic;
using WebShop.BLL.ViewModels;
using WebShop.DAL.Interfaces;

namespace WebShop.BLL.ProductsAdmin
{
    [Service]
    public class GetProductsAdmin
    {
        private IProductManager productManager;

        public GetProductsAdmin(IProductManager productManager)
        {
            this.productManager = productManager;
        }
        
        //expression niet statement ///ENumerable or collections 
        public IEnumerable<ProductViewModelAdmin> DoGetProducts() => 
            productManager.GetProductsWithStock(productAdmin => new ProductViewModelAdmin
            {
                Id = productAdmin.Id,
                Name = productAdmin.Name,
                Description = productAdmin.Description,
                Price = productAdmin.Price,
            });
    }
}