using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController : ControllerBase
    {
        private readonly IUserPermissionService _userPermissionService;

        public UserPermissionController(IUserPermissionService userPermissionService)
        {
            _userPermissionService = userPermissionService;
        }

        [HttpGet(Name = "FetchAllUserPermission")]
        [ProducesResponseType(typeof(IEnumerable<UserPermission>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchAllUserPermission(CancellationToken cancellationToken)
        {
            var data = await _userPermissionService.GetAllAsync(cancellationToken);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetUserPermissionById")]
        [ProducesResponseType(typeof(UserPermission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserPermissionById(int id, CancellationToken cancellationToken)
        {
            var item = await _userPermissionService.GetByIdAsync(id, cancellationToken);
            if (item == null) return NotFound($"No se encontró un user permission con ID {id}");
            return Ok(item);
        }

        [HttpPost(Name = "CreateUserPermission")]
        [ProducesResponseType(typeof(UserPermission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserPermission(UserPermission userPermission, CancellationToken cancellationToken)
        {
            var created = await _userPermissionService.AddAsync(userPermission, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateUserPermission")]
        [ProducesResponseType(typeof(UserPermission), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserPermission(int id, UserPermission userPermission, CancellationToken cancellationToken)
        {
            var updated = await _userPermissionService.UpdateAsync(userPermission, cancellationToken);
            if (updated == null) return NotFound($"No se encontró un user permission con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteUserPermission")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserPermission(int id, CancellationToken cancellationToken)
        {
            var deleted = await _userPermissionService.DeleteAsync(id, cancellationToken);
            if (!deleted) return NotFound($"No se encontró un user permission con ID {id}");
            return Ok(true);
        }
    }
}
