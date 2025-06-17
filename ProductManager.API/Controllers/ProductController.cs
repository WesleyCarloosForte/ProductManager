using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.Common.Response;
using ProductManager.Application.Products.Commands.CreateProduct;
using ProductManager.Application.Products.Commands.DeleteProduct;
using ProductManager.Application.Products.Commands.UpdateProduct;
using ProductManager.Application.Products.Queries.GetAllProduct;
using ProductManager.Application.Products.Queries.GetProductById;
using ProductManager.Domain.Entities;

namespace ProductManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController: ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> Create(CreateProductCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { id });
        }

        [HttpPut]
        public async Task<ActionResult<Result<Product>>> Update(UpdateProductCommand command)
        {
            var product = await _mediator.Send(command);
            return Ok(  product );
        }

        [HttpGet("byId/{id}")]
        public async Task<ActionResult<Result<Product>>> GetById(Guid id)
        {

            var query = new GetProductByIdQuery(id);

            var result = await _mediator.Send(query);
            return Ok(new { result });
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Result<Product>>> Delete(Guid id)
        {

            var command = new DeleteProductCommand(id);

            var result = await _mediator.Send(command);
            return Ok(new { result });
        }
        [HttpGet("all")]
        public async Task<ActionResult<Result<IEnumerable<Product>>>> GetAll()
        {
            var query = new GetAllProductQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
