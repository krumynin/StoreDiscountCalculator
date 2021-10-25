using System.Collections.Generic;
using StoreDiscountCalculator.Components;

namespace StoreDiscountCalculator.Strategy
{
    public interface IProductFilterStrategy
    {
        public List<Product> Filter(List<Product> products);
    }
}