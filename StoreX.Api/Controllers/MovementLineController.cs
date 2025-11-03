using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementLineController : ControllerBase
    {
        private readonly IMovementLineService _movementLineService;

        public MovementLineController(IMovementLineService movementLineService)
        {
            _movementLineService = movementLineService;
        }

        [HttpGet(Name = "FetchAllMovementLine")]
        [ProducesResponseType(typeof(IEnumerable<MovementLine>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllMovementLine(CancellationToken cancellationToken)
        {
            var data = await _movementLineService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetMovementLineById")]
        [ProducesResponseType(typeof(MovementLine), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetMovementLineById(int id, CancellationToken cancellationToken)
        {
            var record = await _movementLineService.GetByIdAsync(id, cancellationToken);
            if (record == null)
                return NotFound($"No se encontró una línea de movimiento con ID {id}");
            return Ok(record);
        }

        [HttpPost(Name = "CreateMovementLine")]
        [ProducesResponseType(typeof(MovementLine), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateMovementLine(MovementLine movementLine, CancellationToken cancellationToken)
        {
            var created = await _movementLineService.AddAsync(movementLine, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateMovementLine")]
        [ProducesResponseType(typeof(MovementLine), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateMovementLine(int id, MovementLine movementLine, CancellationToken cancellationToken)
        {
            var updated = await _movementLineService.UpdateAsync(movementLine, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró una línea de movimiento con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteMovementLine")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteMovementLine(int id, CancellationToken cancellationToken)
        {
            var deleted = await _movementLineService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró una línea de movimiento con ID {id}");
            return Ok(true);
        }
    }
}
