using Moq;
using WebShop.DAL.Interfaces;

namespace TestLibrary
{
    /// <summary>
    /// Helaas door gebrek aan tijd is deze test niet geimplementeerd. 
    /// Zie "StockTest.cs" voor vergelijkbare implementatie
    /// </summary>

    public class OrderTest
    {
        private readonly Mock<IOrderManager> moqIOrderManager;


        public OrderTest()
        {
            moqIOrderManager = new Mock<IOrderManager>();
        }
    }
}
