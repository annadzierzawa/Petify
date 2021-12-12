using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petify.Common.Auth.Access.Attributes;
using Petify.Common.Auth.Access.Lookups;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Commands.Advertisements;
using Petify.PublishedLanguage.Queries.Advertisements;

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

        [RequireFullAccessLevel(Actions.ManageMyAdvertisements)]
        [HttpGet("/users/{userId}/advertisements")]
        public async Task<IActionResult> GetAdvertisements([FromRoute] GetAdvertisementsParameter query)
        {
            var result = await _queryDispatcher.Dispatch(query);
            return Ok(result);
        }

        [RequireFullAccessLevel(Actions.ManageMyAdvertisements)]
        [HttpGet("/users/{userId}/advertisements/{id}/editing-data")]
        public async Task<IActionResult> GetAdvertisementEditingData([FromRoute] GetAdvertisementEditingDataParameter query)
        {
            var result = await _queryDispatcher.Dispatch(query);
            return Ok(result);
        }

        [RequireFullAccessLevel(Actions.ManageMyAdvertisements)]
        [HttpPost("advertisements")]
        public async Task<IActionResult> AddAdvertisement([FromBody] AddAdvertisementCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [RequireFullAccessLevel(Actions.ManageMyAdvertisements)]
        [HttpPut("advertisements/{id}")]
        public async Task<IActionResult> UpdateAdvertisement([FromBody] UpdateAdvertisementCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [RequireFullAccessLevel(Actions.ManageMyAdvertisements)]
        [HttpDelete("advertisements/{id}")]
        public async Task<IActionResult> RemoveAdvertisement([FromRoute] RemoveAdvertisementCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("advertisements/search")]
        public async Task<IActionResult> GetAdvertisementsForSearch([FromQuery] GetAdvertisementsForSearchParameter query)
        {
            var result = await _queryDispatcher.Dispatch(query);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("advertisements/{id}")]
        public async Task<IActionResult> GetAdvertisement([FromRoute] GetAdvertisementParameter query)
        {
            var result = await _queryDispatcher.Dispatch(query);
            return Ok(result);
        }
    }
}
