using Microsoft.AspNetCore.Mvc;
using Service.Application.Users.Commands.CreateUser;
using Service.Application.Users.Commands.DeleteUser;
using Service.Application.Users.Commands.UpdateUser;
using Service.Application.Users.Queries.GetAllUsers;
using Service.Application.Users.Queries.GetUserById;
using Service.Domain.Users.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserWebApi.Controllers
{
    public class UserController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update([FromBody] UpdateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Delete(string id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Getall()
        {
            return await Mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            return await Mediator.Send(new GetUserByIdQuery { Id = id});
        }
    }
}
