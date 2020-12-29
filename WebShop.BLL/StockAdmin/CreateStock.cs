using System.Threading.Tasks;
using WebShop.DAL.Interfaces;
using WebShop.Models.DALModels;

namespace WebShop.BLL.StockAdmin
{
    [Service]
    public class CreateStock
    {
        private readonly IStockManager stockManager;

        public CreateStock(IStockManager stockManager)
        {
            this.stockManager = stockManager;
        }
        
        public async Task<Stock> DoMakeStock(Stock newStock)
        {
            var stock = new Stock
            {
                Description = newStock.Description,
                Quantity = newStock.Quantity,
                ProductId = newStock.ProductId
            };

            await stockManager.CreateStock(stock);

            return new Stock
            {
                Id = stock.Id,
                Description = stock.Description,
                Quantity = stock.Quantity
            };
        }
    }
}

