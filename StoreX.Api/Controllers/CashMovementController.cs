using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashMovementController : ControllerBase
    {
        private readonly ICashMovementService _cashMovementService;

        public CashMovementController(ICashMovementService cashMovementService)
        {
            _cashMovementService = cashMovementService;
        }

        [HttpGet(Name = "FetchAllCashMovements")]
        [ProducesResponseType(typeof(IEnumerable<CashMovement>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllCashMovements(CancellationToken cancellationToken)
        {
            var data = await _cashMovementService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetCashMovementById")]
        [ProducesResponseType(typeof(CashMovement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetCashMovementById(int id, CancellationToken cancellationToken)
        {
            var record = await _cashMovementService.GetByIdAsync(id, cancellationToken);
            if (record == null)
                return NotFound($"No se encontró movimiento de caja con ID {id}");
            return Ok(record);
        }

        [HttpPost(Name = "CreateCashMovement")]
        [ProducesResponseType(typeof(CashMovement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateCashMovement(CashMovement cashMovement, CancellationToken cancellationToken)
        {
            var created = await _cashMovementService.AddAsync(cashMovement, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateCashMovement")]
        [ProducesResponseType(typeof(CashMovement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateCashMovement(int id, CashMovement cashMovement, CancellationToken cancellationToken)
        {
            var updated = await _cashMovementService.UpdateAsync(cashMovement, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró movimiento de caja con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteCashMovement")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteCashMovement(int id, CancellationToken cancellationToken)
        {
            var deleted = await _cashMovementService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró movimiento de caja con ID {id}");
            return Ok(true);
        }
    }
}
