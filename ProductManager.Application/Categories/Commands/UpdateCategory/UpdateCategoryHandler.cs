using MediatR;
using ProductManager.Application.Common.Exceptions;
using ProductManager.Application.Common.Response;
using ProductManager.Domain.Common;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using ProductManager.Domain.ValueObjects.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Result<Category>>
    {
        private readonly IRepository<Category> _categoryRepository;
        public UpdateCategoryHandler(IRepository<Category> repository) 
        {       
            _categoryRepository = repository;
        }
        public async Task<Result<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await _categoryRepository.GetByIdAsync(request.id);

            if (existCategory == null) throw new NotFoundException("Category not found!.");

            existCategory.UpdatedAt = DateTime.UtcNow;
            existCategory.Name = CategoryName.Create(request.name);
            

             _categoryRepository.Update(existCategory);

            await _categoryRepository.SaveChangesAsync();

            return Result<Category>.Success(existCategory);
        }
    }
}
