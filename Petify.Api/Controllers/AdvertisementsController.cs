using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Commands.Advertisements;

namespace Petify.Api.Controllers
{
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public AdvertisementsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost("advertisements")]
        public async Task<IActionResult> AddAdvertisement([FromBody] AddAdvertisementCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [HttpPut("advertisements/{id}")]
        public async Task<IActionResult> UpdateAdvertisement([FromBody] UpdateAdvertisementCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [HttpDelete("advertisements/{id}")]
        public async Task<IActionResult> RemoveAdvertisement([FromRoute] RemoveAdvertisementCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
