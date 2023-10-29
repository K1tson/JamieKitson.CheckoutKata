using CheckoutKata.Core.Data.Repository;
using CheckoutKata.Core.Enums;
using CheckoutKata.Core.Models;
using CheckoutKata.Core.UseCase;
using Moq;
using Xunit;

namespace CheckoutKata.Core.Tests.UseCase
{
    public class AddItemToBasketHandlerTests : TestBase
    {
        private readonly Mock<IBasketItemRepository> _basketItemRepositoryMock;
        private readonly AddItemsToBasketHandler _sut;


        public AddItemToBasketHandlerTests()
        {
            _basketItemRepositoryMock = new Mock<IBasketItemRepository>();
            _sut = new AddItemsToBasketHandler(_basketItemRepositoryMock.Object);
        }


        [Fact]
        public async Task Handler_Returns_Total_Sum_From_Basket_One_Item_Result()
        {

            // Arrange
            var request = new AddItemsToBasketRequest
            {
                BasketItems = new List<BasketItem> { new BasketItem
                {
                    ItemSKU = "A",
                    Promotions = null,
                    UnitPrice = 10
                } }
            };

            // Act
            var result = await _sut.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.TotalCost);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Handler_Returns_Total_Sum_From_Basket_Multiple_Item_Result()
        {

            // Arrange
            var request = new AddItemsToBasketRequest
            {
                BasketItems = new List<BasketItem> {
                    new BasketItem
                    {
                        ItemSKU = "A",
                        Promotions = null,
                        UnitPrice = 10
                    },
                    new BasketItem
                    {
                        ItemSKU = "B",
                        Promotions = Promotions.PromotionOne,
                        UnitPrice = 15
                    },
                    new BasketItem
                    {
                        ItemSKU = "B",
                        Promotions = Promotions.PromotionOne,
                        UnitPrice = 15
                    },
                    new BasketItem
                    {
                        ItemSKU = "B",
                        Promotions = Promotions.PromotionOne,
                        UnitPrice = 15
                    }
                }
            };

            // Act
            var result = await _sut.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.TotalCost);
            Assert.True(result.IsSuccess);
        }
    }
}
