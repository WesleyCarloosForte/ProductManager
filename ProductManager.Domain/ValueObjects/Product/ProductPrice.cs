using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.ValueObjects.Product
{
    public class ProductPrice:IEquatable<ProductPrice>
    {
        public decimal Value {  get;}

        public ProductPrice(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("Price cannot be negative.");

            this.Value = value;
        }

        public bool Equals(ProductPrice? other)
        {
            if (other == null) return false;

            return Value == other.Value;
        }
        public override bool Equals(object? obj) => base.Equals(obj as ProductPrice);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();

        public static ProductPrice Create(decimal value)=> new ProductPrice(value);
    }
}
