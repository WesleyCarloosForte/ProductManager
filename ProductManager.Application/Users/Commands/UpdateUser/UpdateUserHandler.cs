using MediatR;
using ProductManager.Application.Common.Exceptions;
using ProductManager.Application.Common.Response;
using ProductManager.Application.DTO;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using ProductManager.Domain.ValueObjects.Product;
using ProductManager.Domain.ValueObjects.User;


namespace ProductManager.Application.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<UserDTO>>
    {
        private readonly IRepository<User> _repository;
        public UpdateUserHandler(IRepository<User> repository) 
        {
            _repository = repository;

        }

        public async Task<Result<UserDTO>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {



            var existUser = await _repository.GetByIdAsync(request.id);



            if (existUser == null)
                throw new NotFoundException("User not found!.");



            existUser.FullName =UserFullName.Create(request.fullName);
            existUser.Permissions = request.Permission;
            existUser.Login = UserLogin.Create(request.login);
 

            _repository.Update(existUser);
            await _repository.SaveChangesAsync();

            return Result<UserDTO>.Success(UserDTO.Create(existUser));
        }
    }
}
