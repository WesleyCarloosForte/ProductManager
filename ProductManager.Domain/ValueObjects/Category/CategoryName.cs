
namespace ProductManager.Domain.ValueObjects.Category
{
    public class CategoryName : IEquatable<CategoryName>
    {
        public string Value { get; }
        public CategoryName(string value)
        {
            if(string.IsNullOrEmpty(value)) throw new ArgumentNullException("Category name is required.");
            Value = value;
        }
        public bool Equals(CategoryName? other) => other!=null && Value == other.Value;
        public override bool Equals(object? obj) => base.Equals(obj as CategoryName);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();

        public static CategoryName Create(string value) => new CategoryName(value);

    }
}
