using MediatR;
using ProductManager.Application.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Users.Commands.DeleteUser
{
   public record DeleteUserCommand(Guid id):IRequest<Result<bool>>;
}
