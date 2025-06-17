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

namespace ProductManager.Application.Products.Commands.CreateProduct
{
    public class CreateProductHandler:IRequestHandler<CreateProductCommand,Result<Guid>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<Category> _categoryRepository;
        public CreateProductHandler(IRepository<Product> repository,IRepository<Category> repositoryCategory) 
        {
            _repository = repository;
            _categoryRepository = repositoryCategory;
        }
        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken) 
        {

            var existCategory = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if(existCategory == null) throw new NotFoundException(nameof(Category),request.CategoryId);

            var product = Product.Create(request.Name, request.Price, request.inStock, request.CategoryId,request.Status);

            await _repository.AddAsync(product);

            await _repository.SaveChangesAsync();

             return Result<Guid>.Success(product.Id);
        }
    }
}
