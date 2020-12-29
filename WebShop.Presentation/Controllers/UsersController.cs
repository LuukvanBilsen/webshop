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
using WebShop.BLL.UserAdmin;

namespace WebShop.Presentation.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class UsersController : Controller
    {
        private CreateUser createUser;

        public UsersController(CreateUser createUser)
        {
            this.createUser = createUser;
        }

        public async Task<IActionResult> CreateUser([FromBody]CreateUser.UserName userName)
        {
            await createUser.DoCreateUser(userName);
            return Ok();
        }


    }
}

