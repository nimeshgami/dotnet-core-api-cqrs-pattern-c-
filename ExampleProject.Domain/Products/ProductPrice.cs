using ExampleProject.Domain.SharedKernel;

namespace ExampleProject.Domain.Products
{
    public class ProductPrice
    {
        public MoneyValue Value { get; private set; }

        private ProductPrice()
        {
            
        }
    }
}