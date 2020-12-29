using System.Collections.Generic;
using WebShop.BLL.ViewModels;
using WebShop.DAL.Interfaces;

namespace WebShop.BLL.Products
{
    [Service]
    public class GetProducts
    {
        private IProductManager productManager;

        public GetProducts(IProductManager productManager)
        {
            this.productManager = productManager;
        }


        public IEnumerable<ProductViewModel> DoGetProducts() =>
           productManager.GetProductsWithStock(product => new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            });
    }
}
