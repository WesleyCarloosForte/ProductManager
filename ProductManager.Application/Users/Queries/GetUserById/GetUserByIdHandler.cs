using MediatR;
using ProductManager.Application.Common.Exceptions;
using ProductManager.Application.Common.Response;
using ProductManager.Application.DTO;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserDTO>>
    {
        private readonly IRepository<User> _repository;
        public GetUserByIdHandler(IRepository<User> repository) 
        {
            _repository=repository;
        }
        public async Task<Result<UserDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.id);

            if (product == null)
                throw new NotFoundException("User not found!.");

            return Result<UserDTO>.Success(UserDTO.Create(product));
        }
    }
}
