using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Stripe;
using WebShop.BLL;
using WebShop.BLL.Cart;
using WebShop.BLL.ViewModels;
using WebShop.DAL;
using WebShop.DAL.Interfaces;
using GetOrderCart = WebShop.BLL.Cart.GetOrder;

namespace WebShop.Presentation
{
    public class PaymentModel : PageModel
    {
        public PaymentModel(IConfiguration config)
        {
            PublicKey = config["Stripe:PublicKey"].ToString();
        }

        public string PublicKey { get; private set; }

        public IActionResult OnGet([FromServices] GetCustomerInformation getCustomerInformation)
        {
            var information = getCustomerInformation.DoCustomerInfo();

            if (information == null)
            {
                return RedirectToPage("/Checkout/CustomerInformation");
            }

            return Page();        
        }

        public async Task<IActionResult> OnPost(
            string stripeEmail, 
            string stripeToken,
            [FromServices] GetOrderCart getOrder,
            [FromServices] CreateOrder createOrder,
            [FromServices] ISessionManager sessionManager)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var cartOrder = getOrder.DoReturnCart();

            var customer = customers.Create(new CustomerCreateOptions
            { 
                Email = stripeEmail, //null
                SourceToken = stripeToken //thru stripe script
            });

            var charge = charges.Create(new ChargeCreateOptions 
            { 
                Amount = cartOrder.GetTotalPrice(),
                Description = "Test With Actual products",
                Currency = "eur",
                CustomerId = customer.Id
            });
            
            //Create order
            var sessionId = HttpContext.Session.Id;

            await createOrder.DoCreateOrder(new StripeDetails
            {
                StripeReference = charge.Id,

                FirstName = cartOrder.CustomerInformation.FirstName,
                LastName = cartOrder.CustomerInformation.LastName,
                Email = cartOrder.CustomerInformation.Email,
                PhoneNumber = cartOrder.CustomerInformation.PhoneNumber,
                Address = cartOrder.CustomerInformation.Address,
                City = cartOrder.CustomerInformation.City,
                PostCode = cartOrder.CustomerInformation.PostCode,

                Stocks = cartOrder.Products.Select(x => new CreateOrder.Stock 
                { 
                    StockId = x.StockId,
                    Quantity = x.Quantity

                }).ToList()
            });
            return RedirectToPage("/Index");
        }
    }
}