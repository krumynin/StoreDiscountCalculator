using System.Collections.Generic;

namespace StoreDiscountCalculator.Components
{
    public class Basket
    {
        private ICollection<Product> _products;

        public Basket()
        {
            _products = new List<Product>();
        }

        public ICollection<Product> GetProducts()
        {
            return _products;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }
    }
}