using MediatR;
using ProductManager.Application.Common.Exceptions;
using ProductManager.Application.Common.Response;
using ProductManager.Application.DTO;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using ProductManager.Domain.ValueObjects.Product;


namespace ProductManager.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Result<ProductDTO>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<Category> _repositoryCategory;
        public UpdateProductHandler(IRepository<Product> repository, IRepository<Category> repositoryCategory) 
        {
            _repository = repository;
            _repositoryCategory = repositoryCategory;
        }

        public async Task<Result<ProductDTO>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var existentCategory = await _repositoryCategory.GetByIdAsync(request.categoryId);

            if (existentCategory == null) throw new NotFoundException("Category not found");

            var existentProduct = await _repository.GetByIdAsync(request.id);



            if (existentProduct == null)
                throw new NotFoundException("Product not found!.");



            existentProduct.InStock = request.inStock;
            existentProduct.Name = ProductName.Create(request.name);
            existentProduct.Price = ProductPrice.Create(request.price);
            existentProduct.CategoryId= request.categoryId;

            
            
   

            _repository.Update(existentProduct);
            await _repository.SaveChangesAsync();

            return Result<ProductDTO>.Success(ProductDTO.Create(existentProduct));
        }
    }
}
