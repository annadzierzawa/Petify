using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Commands.Users;

namespace Petify.Api.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public UsersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [AllowAnonymous]
        [HttpPost("users/init-user")]
        public async Task<IActionResult> InitUser([FromBody] InitUserCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
