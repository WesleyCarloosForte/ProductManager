using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Result<Guid>>
    {
        private readonly IRepository<Category> _categoryRepository;
        public CreateCategoryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = Category.Create(request.name);

            await _categoryRepository.AddAsync(category);

            await _categoryRepository.SaveChangesAsync();
                
            return Result<Guid>.Success(category.Id);
        }
    }
}
