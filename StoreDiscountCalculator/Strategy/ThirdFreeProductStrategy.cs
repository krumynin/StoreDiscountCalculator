using System.Collections.Generic;
using StoreDiscountCalculator.Components;

namespace StoreDiscountCalculator.Strategy
{
    public class ThirdFreeProductStrategy : IProductFilterStrategy
    {
        public List<Product> Filter(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    products.RemoveAt(i);
                }
            }

            return products;
        }
    }
}