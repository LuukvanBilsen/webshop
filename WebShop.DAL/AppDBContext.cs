using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebShop.Models.DALModels;

namespace WebShop.DAL
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {   }

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderStocks> OrderStocks { get; set; }

        //Override zorgt dat base zoals identityuserLogin niet werken
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<OrderStocks>()
                .HasKey(link => new { link.StockId, link.OrderId });
        }
    }
}
