using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.DAL.Interfaces;
using WebShop.Models.DALModels;

namespace WebShop.DAL.Managers
{
    public class ProductManager : IProductManager
    {

        private AppDBContext context;

        public ProductManager(AppDBContext context)
        {
            this.context = context;
        }

        public Task<int> CreateProduct(Product product)
        {
            context.Products.Add(product);

            return context.SaveChangesAsync();
        }

        public Task<int> DeleteProduct(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            context.Products.Remove(product);

            return context.SaveChangesAsync();
        }

        public Task<int> UpdateProduct(Product product)
        {
            context.Products.Update(product);

            return context.SaveChangesAsync();
        }

        public TResult GetProductById<TResult>(int id, Func<Product, TResult> selector)
        {
            return context.Products
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        public TResult GetProductByName<TResult>(
            string name,
            Func<Product, TResult> selector)
        {
            return context.Products
                .Include(x => x.Stocks)
                .Where(x => x.Name == name)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetProductsWithStock<TResult>(
            Func<Product, TResult> selector)
        {
            return context.Products
                .Include(x => x.Stocks)
                .Select(selector)
                .ToList();
        }
    }
}
