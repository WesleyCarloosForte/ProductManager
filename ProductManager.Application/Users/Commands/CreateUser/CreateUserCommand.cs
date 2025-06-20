using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Domain.Common.Enums;


namespace ProductManager.Application.Users.Commands.CreateUser
{
   public record CreateUserCommand(string fullName,string login,string password,List<Permission> Permission, EntityStatus Status = EntityStatus.Enabled) : IRequest<Result<Guid>>;

}
