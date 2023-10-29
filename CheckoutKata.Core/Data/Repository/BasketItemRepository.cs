using CheckoutKata.Core.Models;

namespace CheckoutKata.Core.Data.Repository
{
    public class BasketItemRepository : IBasketItemRepository
    {
        public async Task<bool> AddBasketItems(IEnumerable<BasketItem> basketItems)
        {
            return await Task.FromResult(basketItems.Any());
        }
    }
}
