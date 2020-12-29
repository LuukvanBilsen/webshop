using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Models.DALModels;

namespace WebShop.DAL.Interfaces
{
    public interface IStockManager
    {
        Task<int> CreateStock(Stock stock);
        Task<int> DeleteStock(int id);
        Task<int> UpdateStockRange(List<Stock> stockList);
        Stock GetStockWithProduct(int stockId);

        bool IsThereStock(int stockId, int quantity);
    }
}
