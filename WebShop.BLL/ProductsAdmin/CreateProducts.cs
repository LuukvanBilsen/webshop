using System;
using System.Threading.Tasks;
using WebShop.BLL.ViewModels;
using WebShop.DAL.Interfaces;
using WebShop.Models.DALModels;

namespace WebShop.BLL.ProductsAdmin
{
    [Service]
    public class CreateProducts
    {
        private IProductManager productManager;

        public CreateProducts(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public async Task<ProductViewModelAdmin> DoCreateProduct(ProductViewModel viewModel)
        {
            var product = new Product
            {
                // Id = Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price
            };

            if (await productManager.CreateProduct(product) <= 0)
            {
                throw new Exception("Product not made");
            }

            return new ProductViewModelAdmin
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }
    }
}
