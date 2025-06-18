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

namespace ProductManager.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Result<bool>>
    {
        private readonly IRepository<Category> _categoryRepository;

        public DeleteCategoryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await _categoryRepository.GetByIdAsync(request.id);

            if (existCategory == null) throw new NotFoundException("Category not found!.");

            _categoryRepository.Delete(existCategory);

            var deleted =await _categoryRepository.SaveChangesAsync();

            return Result<bool>.Success(deleted);

        }
    }
}
