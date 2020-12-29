using System.Threading.Tasks;
using WebShop.DAL.Interfaces;

namespace WebShop.BLL.StockAdmin
{
    [Service]
    public class DeleteStock
    {
        private readonly IStockManager stockManager;

        public DeleteStock(IStockManager stockManager)
        {
            this.stockManager = stockManager;
        }

        public Task<int> DoDeleteStock(int id)
        {
            return stockManager.DeleteStock(id);
        }
    }
}
