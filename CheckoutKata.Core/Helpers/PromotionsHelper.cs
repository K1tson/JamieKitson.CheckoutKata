﻿using CheckoutKata.Core.Enums;
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
            return 0;
        }

        private static decimal CalculatePromotionTwo(IEnumerable<BasketItem> basketItems)
        {
            return 0;
        }

    }
}