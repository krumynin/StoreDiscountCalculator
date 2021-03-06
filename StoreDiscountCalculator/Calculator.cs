using System.Collections.Generic;
using System.Linq;
using StoreDiscountCalculator.Clients;
using StoreDiscountCalculator.Components;
using StoreDiscountCalculator.Strategy;

namespace StoreDiscountCalculator
{
    public class Calculator
    {
        private IDiscountClient _client;
        private IProductFilterStrategy _filter;

        public Calculator(IDiscountClient client, IProductFilterStrategy filter)
        {
            _client = client;
            _filter = filter;
        }

        public float GetTotalPrice(Basket basket)
        {
            var products = _filter.Filter(basket.GetProducts());
            var codes = products.Select(p => p.GetCode()).Distinct().ToArray();

            var discounts = _client.GetDiscountByCodes(codes);

            float totalPrice = 0;
            foreach (var product in products)
            {
                var productDiscount = GetProductDiscount(product, discounts);
                totalPrice += product.GetPrice() * (1 - productDiscount / 100);
            }

            return totalPrice;
        }

        private float GetProductDiscount(Product product, Dictionary<string, float> discounts)
        {
            var code = product.GetCode();
            var productDiscount = discounts.ContainsKey(code)
                ? discounts[code]
                : 0;

            if (productDiscount < 0 || productDiscount > 100)
            {
                productDiscount = 0;
            }

            return productDiscount;
        }
    }
}