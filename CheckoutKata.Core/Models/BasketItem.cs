using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutKata.Core.Enums;

namespace CheckoutKata.Core.Models
{
    public class BasketItem
    {
        public string ItemSKU { get; set; }
        public decimal UnitPrice { get; set; }
        public Promotions? Promotions { get; set; }
    }
}
