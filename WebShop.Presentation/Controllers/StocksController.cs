using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebShop.BLL.StockAdmin;
using Microsoft.AspNetCore.Authorization;
using WebShop.Models.DALModels;

namespace WebShop.Presentation.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class StocksController : Controller
    {
        //Stock-----
        //Create
        [HttpPost("")]
        public async Task<IActionResult> CreateStock(
            [FromServices] CreateStock createStock,
            [FromBody] Stock createStockModel)=> //CreateStock.Request createStockModel) =>
                Ok(await createStock.DoMakeStock(createStockModel)); 

        //Read
        [HttpGet("")]
        public IActionResult GetStock([FromServices] GetStock getStock) =>
            Ok(getStock.DoGetStocks());

        //Update
        [HttpPut("")]
        public async Task<IActionResult> UpdateStock(
            [FromServices] UpdateStock updateStock,
            [FromBody] StockListToUpdate request) => 
            Ok(await updateStock.DoUpdateStock(request));

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(
            [FromServices] DeleteStock deleteStock, int id) => 
            Ok(await deleteStock.DoDeleteStock(id));
    }
}
