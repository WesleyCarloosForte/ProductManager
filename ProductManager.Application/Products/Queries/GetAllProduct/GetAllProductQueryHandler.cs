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

namespace ProductManager.Application.Products.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler:IRequestHandler<GetAllProductQuery,Result<IEnumerable<ProductDTO>>>
    {
        private readonly IRepository<Product> _repository;
        public GetAllProductQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;

        }

        public async Task<Result<IEnumerable<ProductDTO>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetAllAsync();

            var dtoElements = ProductDTO.CreateRange(items);

            return Result<IEnumerable < ProductDTO >>.Success(dtoElements);
        }
    }
}
