using Xunit;
using Moq;
using WebShop.Models.DALModels;
using WebShop.DAL.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestLibrary
{
    public class StockTest
    {
        private readonly Mock<IStockManager> moqIStockManager;
 
        public StockTest() 
        {
            moqIStockManager = new Mock<IStockManager>();
        }

        [Fact]
        public async Task TestGetStock()
        {
            //Arrange
            var ExpectedproductId = 0;
            var productTest = new Stock 
            {
                Id = 0,
                Name = "testName",
                Description = "testDescription",
                Quantity = 99,
                ProductId = ExpectedproductId
            };
            moqIStockManager.Setup(moqManager => moqManager.GetStockWithProduct(ExpectedproductId)).Returns(productTest);

            //Act
            var outcome = moqIStockManager.Object.GetStockWithProduct(0);

            //Assert
            Assert.Equal(ExpectedproductId, outcome.Id);
        }

        [Fact]
        public async Task TestDeleteStock()
        {
            //Arrange
            var productId = 0;
            int expectedOnSucces = 1;
            moqIStockManager.Setup(moqManager => moqManager.DeleteStock(productId)).ReturnsAsync(1);

            //Act
            var outcome = moqIStockManager.Object.DeleteStock(0);

            //Assert
            Assert.Equal(expectedOnSucces, outcome.Result);
        }

        [Fact]
        public async Task TestCreateStock()
        {
            //Arrange
            var expectedOnSucces = 1; 
            var productTest = new Stock
            {
                Id = 0,
                Name = "testName",
                Description = "testDescription",
                Quantity = 99,
                ProductId = 7
            };
            moqIStockManager.Setup(moqManager => moqManager.CreateStock(productTest)).ReturnsAsync(1);

            //Act
            var outcome = moqIStockManager.Object.CreateStock(productTest);

            //Assert
            Assert.Equal(expectedOnSucces, outcome.Result);
        }

        [Fact]
        public async Task TestUpdateStock()
        {
            //Arrange
            var expectedOnSucces = 1; 

            var stocks = new List<Stock>();
            var productsTest = new List<Stock>();
            var productTest = new Stock
            {
                Id = 0,
                Name = "testName",
                Description = "testDescription",
                Quantity = 99,
                ProductId = 3
            };
            productsTest.Add(productTest);
            moqIStockManager.Setup(moqManager => moqManager.UpdateStockRange(productsTest)).ReturnsAsync(1);

            //Act
            var outcome = moqIStockManager.Object.UpdateStockRange(productsTest);

            //Assert
            Assert.Equal(expectedOnSucces, outcome.Result);
        }
    }
}
