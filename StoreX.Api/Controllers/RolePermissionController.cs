using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionService _rolePermissionService;

        public RolePermissionController(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService = rolePermissionService;
        }

        [HttpGet(Name = "FetchAllRolePermission")]
        [ProducesResponseType(typeof(IEnumerable<RolePermission>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchAllRolePermission(CancellationToken cancellationToken)
        {
            var data = await _rolePermissionService.GetAllAsync(cancellationToken);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetRolePermissionById")]
        [ProducesResponseType(typeof(RolePermission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRolePermissionById(int id, CancellationToken cancellationToken)
        {
            var item = await _rolePermissionService.GetByIdAsync(id, cancellationToken);
            if (item == null) return NotFound($"No se encontró un role permission con ID {id}");
            return Ok(item);
        }

        [HttpPost(Name = "CreateRolePermission")]
        [ProducesResponseType(typeof(RolePermission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRolePermission(RolePermission rolePermission, CancellationToken cancellationToken)
        {
            var created = await _rolePermissionService.AddAsync(rolePermission, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateRolePermission")]
        [ProducesResponseType(typeof(RolePermission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRolePermission(int id, RolePermission rolePermission, CancellationToken cancellationToken)
        {
            var updated = await _rolePermissionService.UpdateAsync(rolePermission, cancellationToken);
            if (updated == null) return NotFound($"No se encontró un role permission con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteRolePermission")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRolePermission(int id, CancellationToken cancellationToken)
        {
            var deleted = await _rolePermissionService.DeleteAsync(id, cancellationToken);
            if (!deleted) return NotFound($"No se encontró un role permission con ID {id}");
            return Ok(true);
        }
    }
}
