using System.Collections.Generic;

namespace WebShop.BLL.ViewModels
{
    public class StockProductViewModel
    {
        public int Id { get; set; }
        public string Description {get; set;}
        public IEnumerable<StockViewModel> Stock { get; set; }
    }
}
