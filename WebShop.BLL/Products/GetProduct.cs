using System.Linq;
using WebShop.DAL.Interfaces;
using WebShop.Models;

namespace WebShop.BLL.Products
{
    [Service]
    public class GetProduct
    {
        private IStockManager stockManager;
        private IProductManager productManager;

        public GetProduct(IStockManager stockManager, IProductManager productManager)
        {
            this.stockManager = stockManager;
            this.productManager = productManager;
        }

        //expression niet statement 
        public ProductWithStock DoGetProduct(string name)
        {
            return productManager
                .GetProductByName(name, product => new ProductWithStock
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,

                    Stock = product.Stocks.Select(stock => new StocksFromProduct
                    {
                        Id = stock.Id,
                        Description = stock.Description,
                        Available = stock.Quantity > 0
                    })
                });
        }
    }
}
