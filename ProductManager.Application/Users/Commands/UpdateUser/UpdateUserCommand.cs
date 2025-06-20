using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Application.DTO;
using ProductManager.Domain.Common.Enums;
using ProductManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(Guid id,string fullName, string login, string password, List<Permission> Permission, EntityStatus Status = EntityStatus.Enabled) : IRequest<Result<UserDTO>>;
  
}
