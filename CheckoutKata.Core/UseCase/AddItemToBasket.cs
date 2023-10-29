using CheckoutKata.Core.Data.Repository;
using CheckoutKata.Core.Models;
using MediatR;

namespace CheckoutKata.Core.UseCase;

public class AddItemsToBasketHandler : IRequestHandler<AddItemsToBasketRequest, AddItemsToBasketResponse>
{
    private readonly IBasketItemRepository _basketItemRepository;

    public AddItemsToBasketHandler(IBasketItemRepository basketItemRepository)
    {
        _basketItemRepository = basketItemRepository;
    }

    public async Task<AddItemsToBasketResponse> Handle(AddItemsToBasketRequest request,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var response = await _basketItemRepository.AddBasketItems(request.BasketItems);

        return new AddItemsToBasketResponse(response, CalculateBasketItemsResult(request.BasketItems));

    }

    private decimal? CalculateBasketItemsResult(IEnumerable<BasketItem> basketItems)
    {
        var groupedItems = basketItems.GroupBy(x => x.ItemSKU);

        return 0;
    }
}

public class AddItemsToBasketRequest : IRequest<AddItemsToBasketResponse>
{
    public IEnumerable<BasketItem> BasketItems { get; set; }
}

public class AddItemsToBasketResponse
{
    public AddItemsToBasketResponse(bool isSuccess, decimal? totalCost)
    {
        IsSuccess = isSuccess;
        TotalCost = totalCost;
    }

    public bool IsSuccess { get; set; }
    public decimal? TotalCost { get; set; }
}