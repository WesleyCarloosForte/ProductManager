using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.Common.Response;
using ProductManager.Application.DTO;
using ProductManager.Application.Users.Commands.CreateUser;
using ProductManager.Application.Users.Commands.DeleteUser;
using ProductManager.Application.Users.Commands.UpdateUser;
using ProductManager.Application.Users.Queries.GetAllUser;
using ProductManager.Application.Users.Queries.GetUserById;


namespace ProductManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> Create(CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { id });
        }

        [HttpPut]
        public async Task<ActionResult<Result<UserDTO>>> Update(UpdateUserCommand command)
        {
            var product = await _mediator.Send(command);
            return Ok(  product );
        }

        [HttpGet("byId/{id}")]
        public async Task<ActionResult<Result<UserDTO>>> GetById(Guid id)
        {

            var query = new GetUserByIdQuery(id);

            var result = await _mediator.Send(query);
            return Ok(new { result });
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Result<UserDTO>>> Delete(Guid id)
        {

            var command = new DeleteUserCommand(id);

            var result = await _mediator.Send(command);
            return Ok(new { result });
        }
        [HttpGet("all")]
        public async Task<ActionResult<Result<IEnumerable<UserDTO>>>> GetAll()
        {
            var query = new GetAllUserQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
