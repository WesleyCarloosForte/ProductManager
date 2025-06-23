using Microsoft.AspNetCore.Identity;
using ProductManager.Domain.ValueObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.ValueObjects.User
{
    public class UserPasswordHash : IEquatable<UserPasswordHash>
    {
        public string Value { get; }

        public UserPasswordHash(string value)
        {
            if (value.Length < 7)
                throw new ArgumentException("Password must be at least 6 characters long.");

            this.Value = value;
        }

        public bool Equals(UserPasswordHash? other)
        {
            if (other == null) return false;

            return Value == other.Value;
        }
        public override bool Equals(object? obj) => obj is UserPasswordHash other && Equals(other);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();

        public static UserPasswordHash Create(string value,bool isHashed=false) 
        {
            value=value.Trim();

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password cannot be empty.");

            if (value.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters long.");

            string hashedPassword;

            if (!isHashed)
            {
                var hasher = new PasswordHasher<object>();
                hashedPassword = hasher.HashPassword(null, value);
            }
            else
                hashedPassword=value;

                return new UserPasswordHash(hashedPassword);
               
        }
        public static bool Verify(string hashPassword,string plainTextPassword)
        {
            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, hashPassword, plainTextPassword);
            return result == PasswordVerificationResult.Success;
        }
        public bool Verify(string plainTextPassword)
        {
            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, this.Value, plainTextPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}

