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

namespace ProductManager.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler:IRequestHandler<DeleteProductCommand,Result<bool>>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var existentProduct = await _repository.GetByIdAsync(request.id);

            if(existentProduct==null)
                throw new NotFoundException(nameof(Product), request.id);

            _repository.Delete(existentProduct);

            var result = await _repository.SaveChangesAsync();

            return Result<bool>.Success(result);

        }
    }
}
