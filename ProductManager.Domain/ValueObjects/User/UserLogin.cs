using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.ValueObjects.User
{
    public class UserLogin:IEquatable<UserLogin>
    {
        public string Value { get; }

        public UserLogin(string value) 
        {
            value = value.Trim();

            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Username is required.");

            if (value.Length < 3)
                throw new ArgumentException("Username must be at least 3 characters long.");

            if (value.Length > 100)
                throw new ArgumentException("Username must not exceed 100 characters.");

            this.Value = value;

        }

        public bool Equals(UserLogin other) 
        {
            if(other == null) return false;

            return Value == other.Value; 
        
        }

        public override bool Equals(object? obj) => obj is UserLogin other && Equals(other);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();

        public static UserLogin Create(string value) => new UserLogin(value);
    }
}
