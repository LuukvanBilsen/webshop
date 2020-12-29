using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.BLL.ProductsAdmin;
using WebShop.DAL;
using WebShop.BLL.ViewModels;
using WebShop.BLL.StockAdmin;
using Microsoft.AspNetCore.Authorization;


namespace WebShop.Presentation.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class OrderController: Controller
    {
        private AppDBContext context;

        public OrderController(AppDBContext context)
        {
            this.context = context;
        }
    }
}
