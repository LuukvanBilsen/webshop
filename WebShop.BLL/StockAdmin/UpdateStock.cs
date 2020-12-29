using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.DAL.Interfaces;
using WebShop.Models.DALModels;

namespace WebShop.BLL.StockAdmin
{
    [Service]
    public class UpdateStock
    {
        private readonly IStockManager stockManager;

        public UpdateStock(IStockManager stockManager)
        {
            this.stockManager = stockManager;
        }

        public async Task<StockListToUpdate> DoUpdateStock(StockListToUpdate stocksOfProduct)
        {
            var stocks = new List<Stock>();

            foreach(var stock in stocksOfProduct.Stock)
            {
                stocks.Add(new Stock
                {
                    Id = stock.Id,
                    Description = stock.Description,
                    Quantity = stock.Quantity,
                    ProductId = stock.ProductId
                });
            }

            await stockManager.UpdateStockRange(stocks);

            return new StockListToUpdate//Updated
            {
                Stock = stocksOfProduct.Stock
            };
        }
    }
}
