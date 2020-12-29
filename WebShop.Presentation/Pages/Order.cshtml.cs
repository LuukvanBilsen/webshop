using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using WebShop.BLL.Order;

namespace WebShop.Presentation.Pages
{
    public class OrderModel : PageModel
    {
        public GetOrder.OrderDetails Order { get; set; }

        public void OnGet(
            string reference,
            [FromServices] GetOrder getOrder)
        {
            Order = getOrder.DoGetOrder(reference);
        }
    }
} 