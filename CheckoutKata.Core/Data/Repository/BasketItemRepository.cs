using CheckoutKata.Core.Models;

namespace CheckoutKata.Core.Data.Repository
{
    public class BasketItemRepository : IBasketItemRepository
    {
        public Task<bool> AddBasketItems(IEnumerable<BasketItem> basketItems)
        {
            return Task.FromResult(basketItems.Any());
        }
    }
}
