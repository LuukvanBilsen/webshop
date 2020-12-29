using WebShop.DAL.Interfaces;
using WebShop.Models;

namespace WebShop.BLL.Cart
{
    [Service]
    public class AddToCart
    {
        private ISessionManager session;
        private IStockManager stockManager;

        public AddToCart(ISessionManager session, IStockManager stockManager)
        {
            this.session = session;
            this.stockManager = stockManager;
        }        

        public void DoAddToCart(CartProduct cartProduct)
        {

            var stock = stockManager.GetStockWithProduct(cartProduct.StockId);

            var newCartProduct = new CartProductView()
            {
                ProductId = stock.ProductId,
                StockId = stock.Id,
                Quantity = cartProduct.Quantity,
                Name = stock.Product.Name,
                Price = stock.Product.Price.ToString(),                
            };
            session.AddProduct(newCartProduct);
        }
    }
}
