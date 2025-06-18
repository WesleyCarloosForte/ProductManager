
namespace ProductManager.Domain.ValueObjects.Product
{
    public class ProductName:IEquatable<ProductName>
    {
        public string Value { get; }

        public ProductName(string value) 
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Product name is required.");

            else if (value.Length < 4)
                throw new ArgumentException("Product name must be at least 4 characters long.");

            else if (value.Length > 100)
                throw new ArgumentException("Product name must not exceed 100 characters.");

            Value = value;
        }

        public bool Equals(ProductName? other)
        {
            if (other==null) return false;

            return Value== other.Value;
        }
        public override bool Equals(object? obj) =>  base.Equals(obj as ProductName);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();

        public static ProductName Create(string value) => new ProductName(value);
        
    }
}
