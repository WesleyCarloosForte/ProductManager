using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Application.DTO;
using ProductManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Users.Queries.GetAllUser
{
    public record GetAllUserQuery():IRequest<Result<IEnumerable<UserDTO>>>;
}
