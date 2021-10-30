using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Queries.Pets;

namespace Petify.Api.Controllers
{
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public PetsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [AllowAnonymous]
        [HttpGet("pets/species-lookup")]
        public async Task<IActionResult> InitUser([FromQuery] GetSpeciesParameter query)
        {
            var result = await _queryDispatcher.Dispatch(query);
            return Ok(result);
        }
    }
}
