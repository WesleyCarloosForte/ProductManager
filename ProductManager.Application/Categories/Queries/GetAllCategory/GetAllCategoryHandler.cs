using MediatR;
using ProductManager.Application.Common.Response;
using ProductManager.Application.DTO;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;


namespace ProductManager.Application.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryCommand, Result<IEnumerable<CategoryDTO>>>
    {
        private readonly IRepository<Category> _categoryRepository;
        public GetAllCategoryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<IEnumerable<CategoryDTO>>> Handle(GetAllCategoryCommand request, CancellationToken cancellationToken)
        {

            var queryResult = await _categoryRepository.GetAllAsync();

            var dtoElements= CategoryDTO.CreateRange(queryResult);

            return Result<IEnumerable<CategoryDTO>>.Success(dtoElements);

        }
    }
}
