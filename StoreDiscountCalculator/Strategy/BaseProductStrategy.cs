using System.Collections.Generic;
using StoreDiscountCalculator.Components;

namespace StoreDiscountCalculator.Strategy
{
    public class BaseProductStrategy : IProductFilterStrategy
    {
        public List<Product> Filter(List<Product> products)
        {
            return products;
        }
    }
}