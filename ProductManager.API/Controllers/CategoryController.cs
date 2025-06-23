using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.Categories.Commands.CreateCategory;
using ProductManager.Application.Categories.Commands.DeleteCategory;
using ProductManager.Application.Categories.Commands.UpdateCategory;
using ProductManager.Application.Categories.Queries.GetAllCategory;
using ProductManager.Application.Categories.Queries.GetCategoryById;
using ProductManager.Application.Common.Response;
using ProductManager.Application.DTO;
using ProductManager.Domain.Entities;

namespace ProductManager.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController:ControllerBase
    {
        private readonly ISender _sender;

        public CategoryController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<Result<IEnumerable<CategoryDTO>>>> GetAll()
        {
            var command = new GetAllCategoryCommand();
            var result = await _sender.Send(command);

            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Result<CategoryDTO>>> GetById(Guid id)
        {
            var command = new GetCategoryByIdCommand(id);
            var result = await _sender.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<CategoryDTO>>> Greate(CreateCategoryCommand command)
        {
            var result = await _sender.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<CategoryDTO>>> Update(UpdateCategoryCommand command)
        {
            var result = await _sender.Send(command);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Result<CategoryDTO>>> delete(Guid id)
        {
            var command = new DeleteCategoryCommand(id);
            var result =await _sender.Send(command);

            return Ok(result);
        }
    }
}
