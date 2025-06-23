using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Application.DTO;
using ProductManager.Domain.Common;
using ProductManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery( Guid id) : IRequest<Result<UserDTO>>;
}
