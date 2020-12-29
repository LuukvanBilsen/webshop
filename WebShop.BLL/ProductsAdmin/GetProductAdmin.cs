using WebShop.BLL.ViewModels;
using WebShop.DAL.Interfaces;

namespace WebShop.BLL.ProductsAdmin
{
    [Service]
    public class GetProductAdmin
    {
        private IProductManager productManager;

        public GetProductAdmin(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        //lambda expressie niet statement ///ENumerable or collections
        public ProductViewModelAdmin DoGetProduct(int id)=>
            productManager.GetProductById(id, productAdmin => new ProductViewModelAdmin
            {
                Id = productAdmin.Id,
                Name = productAdmin.Name,
                Description = productAdmin.Description,
                Price = productAdmin.Price,
            });
    }
}