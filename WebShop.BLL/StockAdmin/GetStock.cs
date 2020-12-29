using System.Collections.Generic;
using System.Linq;
using WebShop.DAL.Interfaces;
using WebShop.Models.DALModels;
//

namespace WebShop.BLL.StockAdmin
{
    [Service]
    public class GetStock
    {
        private IProductManager productManager;

        public GetStock(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public IEnumerable<StockProductViewModel> DoGetStocks()
        {
            return productManager.GetProductsWithStock(product =>
            new StockProductViewModel
            {
                Id = product.Id,
                Description = product.Description,
                Stock = product.Stocks.Select(stockView => new Stock
                {
                    Id = stockView.Id,
                    Description = stockView.Description,
                    Quantity = stockView.Quantity,
                })
            });
        }
    }
}
