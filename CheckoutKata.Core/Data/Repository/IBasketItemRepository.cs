using CheckoutKata.Core.Models;

namespace CheckoutKata.Core.Data.Repository;

public interface IBasketItemRepository : IRepository
{ 
    Task<bool> AddBasketItems(IEnumerable<BasketItem> basketItems);
}