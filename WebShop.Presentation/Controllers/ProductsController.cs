using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebShop.BLL.ProductsAdmin;
using WebShop.BLL.ViewModels;
using Microsoft.AspNetCore.Authorization;


namespace WebShop.Presentation.Controllers
{

    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class ProductsController: Controller
    {

        //Product-----
        //Create
        [HttpPost("")]
        public async Task<IActionResult> CreateProduct(
            [FromBody] ProductViewModel viewModel,
            [FromServices] CreateProducts createProduct) => 
            Ok(await createProduct.DoCreateProduct(viewModel));

        //Read (more)
        [HttpGet("")]
        public IActionResult GetProducts([FromServices] GetProductsAdmin getProducts) =>
           Ok(getProducts.DoGetProducts());

        //Read (one)
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id, [FromServices] GetProductAdmin getProduct) =>
           Ok(getProduct.DoGetProduct(id));

        //Update
        [HttpPut("")]
        public async Task<IActionResult> UpdateProduct(
            [FromBody] ProductViewModelAdmin viewModel,
            [FromServices] UpdateProduct updateProduct) =>
            Ok(await updateProduct.DoUpdateProduct(viewModel));

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id, [FromServices] DeleteProduct deleteProduct) =>
            Ok(await deleteProduct.Do(id));


    }
}