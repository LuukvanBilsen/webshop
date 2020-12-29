using System.Threading.Tasks;
using WebShop.DAL.Interfaces;

namespace WebShop.BLL.ProductsAdmin
{
    [Service]
    public class DeleteProduct
    {
        private IProductManager productManager;

        public DeleteProduct(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public Task<int> Do(int id)
        {
            return productManager.DeleteProduct(id);
        }
    }
}