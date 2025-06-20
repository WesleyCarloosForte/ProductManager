using ProductManager.Domain.Common;
using ProductManager.Domain.Common.Enums;
using ProductManager.Domain.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.Entities
{
    public class User:BaseEntity
    {
        public UserFullName FullName { get; set; }
        public UserLogin Login { get; set; }
        public UserPasswordHash PasswordHash { get; set; }
        public List<Permission> Permissions { get; set; }

        public List<string> ConvertAllPermissionToString()
        {
            var list = new List<string>();

            foreach(var permission in Permissions)
            {
                list.Add(permission.ToString());
            }

            return list;

        }

        public User() 
        {

        }

        public User(string fullName,string login, string password, List<Permission> permissions,bool isHashed=false)
        {
            FullName=UserFullName.Create(fullName);
            Login = UserLogin.Create(login);
            PasswordHash = UserPasswordHash.Create(password);
            Permissions = permissions;
        }

        public static User Create(string fullName,string login, string password, List<Permission> permissions, bool isHashed = false) =>  new User(fullName,login, password, permissions, isHashed);
    }
}
