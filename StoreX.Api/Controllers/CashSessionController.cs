using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashSessionController : ControllerBase
    {
        private readonly ICashSessionService _cashSessionService;

        public CashSessionController(ICashSessionService cashSessionService)
        {
            _cashSessionService = cashSessionService;
        }

        [HttpGet(Name = "FetchAllCashSessions")]
        [ProducesResponseType(typeof(IEnumerable<CashSession>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllCashSessions(CancellationToken cancellationToken)
        {
            var data = await _cashSessionService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetCashSessionById")]
        [ProducesResponseType(typeof(CashSession), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetCashSessionById(int id, CancellationToken cancellationToken)
        {
            var record = await _cashSessionService.GetByIdAsync(id, cancellationToken);
            if (record == null)
                return NotFound($"No se encontró sesión de caja con ID {id}");
            return Ok(record);
        }

        [HttpPost(Name = "CreateCashSession")]
        [ProducesResponseType(typeof(CashSession), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateCashSession(CashSession cashSession, CancellationToken cancellationToken)
        {
            var created = await _cashSessionService.AddAsync(cashSession, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateCashSession")]
        [ProducesResponseType(typeof(CashSession), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateCashSession(int id, CashSession cashSession, CancellationToken cancellationToken)
        {
            var updated = await _cashSessionService.UpdateAsync(cashSession, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró sesión de caja con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteCashSession")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteCashSession(int id, CancellationToken cancellationToken)
        {
            var deleted = await _cashSessionService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró sesión de caja con ID {id}");
            return Ok(true);
        }
    }
}
