using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryCommand, Result<IEnumerable<Category>>>
    {
        private readonly IRepository<Category> _categoryRepository;
        public GetAllCategoryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<IEnumerable<Category>>> Handle(GetAllCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAllAsync();

            return Result<IEnumerable<Category>>.Success(result);
        }
    }
}
