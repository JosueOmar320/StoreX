using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet(Name = "FetchAllPermission")]
        [ProducesResponseType(typeof(IEnumerable<Permission>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchAllPermission(CancellationToken cancellationToken)
        {
            var data = await _permissionService.GetAllAsync(cancellationToken);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetPermissionById")]
        [ProducesResponseType(typeof(Permission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPermissionById(int id, CancellationToken cancellationToken)
        {
            var permission = await _permissionService.GetByIdAsync(id, cancellationToken);
            if (permission == null) return NotFound($"No se encontró un permission con ID {id}");
            return Ok(permission);
        }

        [HttpPost(Name = "CreatePermission")]
        [ProducesResponseType(typeof(Permission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePermission(Permission permission, CancellationToken cancellationToken)
        {
            var created = await _permissionService.AddAsync(permission, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdatePermission")]
        [ProducesResponseType(typeof(Permission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePermission(int id, Permission permission, CancellationToken cancellationToken)
        {
            var updated = await _permissionService.UpdateAsync(permission, cancellationToken);
            if (updated == null) return NotFound($"No se encontró un permission con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeletePermission")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePermission(int id, CancellationToken cancellationToken)
        {
            var deleted = await _permissionService.DeleteAsync(id, cancellationToken);
            if (!deleted) return NotFound($"No se encontró un permission con ID {id}");
            return Ok(true);
        }
    }
}
