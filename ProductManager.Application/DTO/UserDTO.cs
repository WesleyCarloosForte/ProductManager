using ProductManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.DTO
{
    public class UserDTO:BaseDTO
    {
        public string FullName { get; set; }
        public string Login { get; set; }
        public List<string> Permission {  get; set; }

        public static UserDTO Create(User user)
        {
            return new UserDTO
            {
                FullName = user.FullName.Value,
                Id = user.Id,
                Permission = user.ConvertAllPermissionToString(),
                Login = user.Login.Value,
                Status = user.Status
            };
        }
        public static IEnumerable<UserDTO> CreateRange(IEnumerable<User> users)
        {
            try
            {

                if (!users.Any())
                    return new List<UserDTO>();

                var elements = new List<UserDTO>();

                foreach (User item in users)
                {
                    elements.Add(UserDTO.Create(item));

                }
                return elements;
            }
            catch (Exception ex)
            {

                return new List<UserDTO>();
            }
        }

    }
}
