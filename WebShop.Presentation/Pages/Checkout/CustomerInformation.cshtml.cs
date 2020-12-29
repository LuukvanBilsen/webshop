using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShop.BLL;
using WebShop.BLL.Cart;
using WebShop.Models;

namespace WebShop.Presentation
{
    public class CustomerInformationModel : PageModel
    {
        [BindProperty]
        public CustomerInfo CustomerInfo {get; set;}

        public IActionResult OnGet([FromServices] GetCustomerInformation getCustomerInformation)
        {
            //GetCart
            var information = getCustomerInformation.DoCustomerInfo();

            if(information == null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("Payment");
            }

            //if card exist to pay
        }
        public IActionResult OnPost([FromServices] AddCustomerInfo addCustomerInfo)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //PostCard
            addCustomerInfo.DoAddCustomerInfo(CustomerInfo);
            return RedirectToPage("Payment"); //37:00
        }
    }
}