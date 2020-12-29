using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebShop.DAL.Interfaces;
using WebShop.Models.DALModels;

namespace WebShop.DAL.Managers
{
    public class StockManager : IStockManager 
    {
        public AppDBContext context;

        public StockManager(AppDBContext context)
        {
            this.context = context;
        }

        public Task<int> CreateStock(Stock stock)
        {
            context.Stocks.Add(stock);

            return context.SaveChangesAsync();
        }

        public Task<int> DeleteStock(int id)
        {
            var stock = context.Stocks.FirstOrDefault(x => x.Id == id);

            context.Stocks.Remove(stock);

            return context.SaveChangesAsync();
        }

        public Task<int> UpdateStockRange(List<Stock> stockList)
        {
            context.Stocks.UpdateRange(stockList);

            return context.SaveChangesAsync();
        }

        public Stock GetStockWithProduct(int stockId)
        {
            return context.Stocks
                .Include(x => x.Product)
                .FirstOrDefault(x => x.Id == stockId);
        }

        public bool EnoughStock(int stockId, int quantity)
        {
            return context.Stocks.FirstOrDefault(x => x.Id == stockId).Quantity >= quantity;
        }

        public bool IsThereStock(int stockId, int quantity)
        {
            return context.Stocks.FirstOrDefault(x => x.Id == stockId).Quantity >= quantity;
        }
    }
}
