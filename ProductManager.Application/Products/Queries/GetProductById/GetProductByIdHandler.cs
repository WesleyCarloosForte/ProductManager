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

namespace ProductManager.Application.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDTO>>
    {
        private readonly IRepository<Product> _repository;
        public GetProductByIdHandler(IRepository<Product> repository) 
        {
            _repository=repository;
        }
        public async Task<Result<ProductDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.id);

            if (product == null)
                throw new NotFoundException("Product not found!.");

            return Result<ProductDTO>.Success(ProductDTO.Create(product));
        }
    }
}
