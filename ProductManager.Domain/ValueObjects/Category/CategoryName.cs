
namespace ProductManager.Domain.ValueObjects.Category
{
    public class CategoryName : IEquatable<CategoryName>
    {
        public string Value { get; }
        public CategoryName(string value)
        {
            if(string.IsNullOrEmpty(value)) throw new ArgumentNullException("Category name is required.");
           
            else if (value.Length < 4)
                throw new ArgumentException("Category name must be at least 4 characters long.");

            else if (value.Length > 100)
                throw new ArgumentException("Category name must not exceed 100 characters.");

            Value = value;
        }
        public bool Equals(CategoryName? other) => other!=null && Value == other.Value;
        public override bool Equals(object? obj) => base.Equals(obj as CategoryName);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();

        public static CategoryName Create(string value) => new CategoryName(value);

    }
}
