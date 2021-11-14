using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petify.Common.CQRS;
using Petify.PublishedLanguage.Commands.Pets;
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

        [HttpPost("pets")]
        public async Task<IActionResult> AddPet([FromBody] AddPetCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [HttpPut("pets")]
        public async Task<IActionResult> UpdatePet([FromBody] UpdatePetCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [HttpGet("pets/{id}")]
        public async Task<IActionResult> GetPet([FromRoute] GetPetParameter query)
        {
            var result = await _queryDispatcher.Dispatch(query);
            return Ok(result);
        }

        [HttpDelete("pets/{id}")]
        public async Task<IActionResult> RemovePet([FromRoute] RemovePetCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [HttpGet("/users/{userId}/pets")]
        public async Task<IActionResult> GetPets([FromRoute] GetPetsParameter query)
        {
            var result = await _queryDispatcher.Dispatch(query);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("pets/images/{fileStorageId}")]
        public async Task<IActionResult> GetPetImage([FromRoute] GetPetImageParameter query)
        {
            var result = await _queryDispatcher.Dispatch(query);

            return File(result, "image/png", "filename.png");
        }
    }
}
