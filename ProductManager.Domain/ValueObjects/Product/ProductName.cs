
namespace ProductManager.Domain.ValueObjects.Product
{
    public class ProductName:IEquatable<ProductName>
    {
        public string Value { get; }

        public ProductName(string value) 
        {
            if(string.IsNullOrEmpty(value)) 
                throw new ArgumentNullException("Product name is required.");

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
