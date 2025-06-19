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

namespace ProductManager.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler:IRequestHandler<GetCategoryByIdCommand,Result<CategoryDTO>>
    {

        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryByIdHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<CategoryDTO>> Handle(GetCategoryByIdCommand request,CancellationToken cancellationToken)
        {
            var existCategory = await _categoryRepository.GetByIdAsync(request.id);

            if (existCategory == null) throw new NotFoundException("Category not found!.");

            return Result<CategoryDTO>.Success(CategoryDTO.Create(existCategory));
        }
    }
}
