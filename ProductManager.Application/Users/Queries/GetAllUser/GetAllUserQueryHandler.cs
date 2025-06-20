using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Application.DTO;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Users.Queries.GetAllUser
{
    public class GetAllUserQueryHandler:IRequestHandler<GetAllUserQuery, Result<IEnumerable<UserDTO>>>
    {
        private readonly IRepository<User> _repository;
        public GetAllUserQueryHandler(IRepository<User> repository)
        {
            _repository = repository;

        }

        public async Task<Result<IEnumerable<UserDTO>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetAllAsync();

            var dtoElements = UserDTO.CreateRange(items);

            return Result<IEnumerable < UserDTO >>.Success(dtoElements);
        }
    }
}
