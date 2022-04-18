using ExampleProject.Domain.SeedWork;
using ExampleProject.Domain.SharedKernel;

namespace ExampleProject.Domain.Products
{
    public class ProductPriceData : ValueObject
    {
        public ProductPriceData(ProductId productId, MoneyValue price)
        {
            ProductId = productId;
            Price = price;
        }

        public ProductId ProductId { get; }

        public MoneyValue Price { get; }
    }
}