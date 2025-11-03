using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet(Name = "FetchAllRole")]
        [ProducesResponseType(typeof(IEnumerable<Role>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchAllRole(CancellationToken cancellationToken)
        {
            var data = await _roleService.GetAllAsync(cancellationToken);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetRoleById")]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRoleById(int id, CancellationToken cancellationToken)
        {
            var role = await _roleService.GetByIdAsync(id, cancellationToken);
            if (role == null) return NotFound($"No se encontró un role con ID {id}");
            return Ok(role);
        }

        [HttpPost(Name = "CreateRole")]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRole(Role role, CancellationToken cancellationToken)
        {
            var created = await _roleService.AddAsync(role, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateRole")]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRole(int id, Role role, CancellationToken cancellationToken)
        {
            var updated = await _roleService.UpdateAsync(role, cancellationToken);
            if (updated == null) return NotFound($"No se encontró un role con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteRole")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRole(int id, CancellationToken cancellationToken)
        {
            var deleted = await _roleService.DeleteAsync(id, cancellationToken);
            if (!deleted) return NotFound($"No se encontró un role con ID {id}");
            return Ok(true);
        }
    }
}
