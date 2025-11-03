using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _movementService;

        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpGet(Name = "FetchAllMovement")]
        [ProducesResponseType(typeof(IEnumerable<Movement>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllMovement(CancellationToken cancellationToken)
        {
            var data = await _movementService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetMovementById")]
        [ProducesResponseType(typeof(Movement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetMovementById(int id, CancellationToken cancellationToken)
        {
            var movement = await _movementService.GetByIdAsync(id, cancellationToken);
            if (movement == null)
                return NotFound($"No se encontró un movimiento con ID {id}");
            return Ok(movement);
        }

        [HttpPost(Name = "CreateMovement")]
        [ProducesResponseType(typeof(Movement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateMovement(Movement movement, CancellationToken cancellationToken)
        {
            var created = await _movementService.AddAsync(movement, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateMovement")]
        [ProducesResponseType(typeof(Movement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateMovement(int id, Movement movement, CancellationToken cancellationToken)
        {
            var updated = await _movementService.UpdateAsync(movement, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró un movimiento con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteMovement")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteMovement(int id, CancellationToken cancellationToken)
        {
            var deleted = await _movementService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró un movimiento con ID {id}");
            return Ok(true);
        }
    }
}
