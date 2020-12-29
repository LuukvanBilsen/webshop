namespace WebShop.Models
{
    public class ProductOrder
    {
        //product thru stockId
        public int ProductId { get; set; }
        public int StockId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}