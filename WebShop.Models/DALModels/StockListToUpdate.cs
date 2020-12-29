using System.Collections.Generic;

namespace WebShop.Models.DALModels
{
    public class StockListToUpdate
    {
        public IEnumerable<StockViewModel> Stock { get; set; }
    }
}
