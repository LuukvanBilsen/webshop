using Moq;
using WebShop.DAL.Interfaces;

namespace TestLibrary
{
    /// <summary>
    /// Helaas door gebrek aan tijd is deze test niet geimplementeerd. 
    /// Zie "StockTest.cs" voor vergelijkbare implementatie
    /// </summary>
   
    public class ProductTest
    {
        private readonly Mock<IProductManager> moqIProductManager;


        public ProductTest()
        {
            moqIProductManager = new Mock<IProductManager>();
        }
    }
}
