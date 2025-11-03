using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet(Name = "FetchAllUserRole")]
        [ProducesResponseType(typeof(IEnumerable<UserRole>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchAllUserRole(CancellationToken cancellationToken)
        {
            var data = await _userRoleService.GetAllAsync(cancellationToken);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetUserRoleById")]
        [ProducesResponseType(typeof(UserRole), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserRoleById(int id, CancellationToken cancellationToken)
        {
            var item = await _userRoleService.GetByIdAsync(id, cancellationToken);
            if (item == null) return NotFound($"No se encontró un user role con ID {id}");
            return Ok(item);
        }

        [HttpPost(Name = "CreateUserRole")]
        [ProducesResponseType(typeof(UserRole), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserRole(UserRole userRole, CancellationToken cancellationToken)
        {
            var created = await _userRoleService.AddAsync(userRole, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateUserRole")]
        [ProducesResponseType(typeof(UserRole), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserRole(int id, UserRole userRole, CancellationToken cancellationToken)
        {
            var updated = await _userRoleService.UpdateAsync(userRole, cancellationToken);
            if (updated == null) return NotFound($"No se encontró un user role con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteUserRole")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserRole(int id, CancellationToken cancellationToken)
        {
            var deleted = await _userRoleService.DeleteAsync(id, cancellationToken);
            if (!deleted) return NotFound($"No se encontró un user role con ID {id}");
            return Ok(true);
        }
    }
}
