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

namespace ProductManager.Application.Users.Commands.DeleteUser
{
    public class DeleteUsertHandler:IRequestHandler<DeleteUserCommand, Result<bool>>
    {
        private readonly IRepository<User> _repository;

        public DeleteUsertHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _repository.GetByIdAsync(request.id);

            if(existUser==null)
                throw new NotFoundException(nameof(User), request.id);

            _repository.Delete(existUser);

            var result = await _repository.SaveChangesAsync();

            return Result<bool>.Success(result);

        }
    }
}
