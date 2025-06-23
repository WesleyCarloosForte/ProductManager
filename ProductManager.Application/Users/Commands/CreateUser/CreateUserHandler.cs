using MediatR;
using ProductManager.Application.Common.Exceptions;
using ProductManager.Application.Common.Response;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Users.Commands.CreateUser
{
    public class CreateUserHandler:IRequestHandler<CreateUserCommand, Result<Guid>>
    {
        private readonly IRepository<User> _repository;

        public CreateUserHandler(IRepository<User> repository) 
        {
            _repository = repository;
       
        }
        public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken) 
        {

            var product = User.Create(request.fullName, request.login,request.password, request.Permission,false);

            await _repository.AddAsync(product);

            await _repository.SaveChangesAsync();

             return Result<Guid>.Success(product.Id);
        }
    }
}
