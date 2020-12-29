using System.Threading.Tasks;
using WebShop.BLL.ViewModels;
using WebShop.DAL.Interfaces;

namespace WebShop.BLL.ProductsAdmin
{
    [Service]
    public class UpdateProduct
    {
        private IProductManager productManager;

        public UpdateProduct(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public async Task<ProductViewModelAdmin> DoUpdateProduct(ProductViewModelAdmin viewModel)
        {
            ////
            var product = productManager.GetProductById(viewModel.Id, productToGet => productToGet);


            product.Name = viewModel.Name;
            product.Description = viewModel.Description;
            product.Price = viewModel.Price;

            await productManager.UpdateProduct(product);

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