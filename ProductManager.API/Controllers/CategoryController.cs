using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.Categories.Commands.CreateCategory;
using ProductManager.Application.Categories.Commands.DeleteCategory;
using ProductManager.Application.Categories.Commands.UpdateCategory;
using ProductManager.Application.Categories.Queries.GetAllCategory;
using ProductManager.Application.Categories.Queries.GetCategoryById;
using ProductManager.Application.Common.Response;
using ProductManager.Domain.Entities;

namespace ProductManager.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController:ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<Result<IEnumerable<Category>>>> GetAll()
        {
            var command = new GetAllCategoryCommand();
            var result = _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Result<Category>>> GetById(Guid id)
        {
            var command = new GetCategoryByIdCommand(id);
            var result = _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Category>>> Greate(CreateCategoryCommand command)
        {
            var result = _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Category>>> Update(UpdateCategoryCommand command)
        {
            var result = _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Result<Category>>> delete(Guid id)
        {
            var command = new DeleteCategoryCommand(id);
            var result = _mediator.Send(command);

            return Ok(result);
        }
    }
}
