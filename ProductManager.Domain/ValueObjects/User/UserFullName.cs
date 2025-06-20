using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.ValueObjects.User
{
    public class UserFullName:IEquatable<UserFullName>
    {
        public string Value { get; }

        public UserFullName(string value)
        {
            value = value.Trim();

            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("FullName is required.");

            if (value.Length < 3)
                throw new ArgumentException("FullName must be at least 3 characters long.");

            if (value.Length > 100)
                throw new ArgumentException("FullName must not exceed 100 characters.");

            this.Value = value;

        }

        public bool Equals(UserFullName other)
        {
            if (other == null) return false;

            return Value == other.Value;

        }

        public override bool Equals(object? obj) => obj is UserFullName other && Equals(other);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();

        public static UserFullName Create(string value) => new UserFullName(value);
    }
}
