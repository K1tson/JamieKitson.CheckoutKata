using CheckoutKata.Core.Enums;
using CheckoutKata.Core.Models;

namespace CheckoutKata.Core.Helpers
{
    public class PromotionsHelper
    {

        public static decimal CalculatePromotions(IEnumerable<BasketItem> basketItems)
        {
            var promotionType = basketItems.First().Promotions;

            if (!basketItems.Any()) return 0;

            return promotionType switch
            {
                Promotions.PromotionOne => CalculatePromotionOne(basketItems),
                Promotions.PromotionTwo => CalculatePromotionTwo(basketItems),
                null => basketItems.Sum(x => x.UnitPrice),
                _ => throw new ArgumentOutOfRangeException()
            };
        }


        private static decimal CalculatePromotionOne(IEnumerable<BasketItem> basketItems)
        {
            var unitPrice = basketItems.First().UnitPrice;
            decimal total = 0;
            var quotient = Math.DivRem(basketItems.Count(), 3, out var remainder);

            total += remainder * unitPrice;
            total += quotient * 40;

            return total;
        }

        private static decimal CalculatePromotionTwo(IEnumerable<BasketItem> basketItems)
        {
            const decimal percentage = 25;
            var unitPrice = basketItems.First().UnitPrice;
            var costPerTwoUnits = unitPrice * 2;
            decimal total = 0;
            var quotient = Math.DivRem(basketItems.Count(), 2, out var remainder);

            for (var i = 0; i < quotient; i++)
            {
                decimal percentSavings = percentage / 100 * costPerTwoUnits;
                total += costPerTwoUnits - percentSavings;
            }

            total += remainder * 55;

            return total;
        }

    }
}
