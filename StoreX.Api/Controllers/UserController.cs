using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "FetchAllUser")]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllUser(CancellationToken cancellationToken)
        {
            var data = await _userService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetUserById")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByIdAsync(id, cancellationToken);
            if (user == null)
                return NotFound($"No se encontró un usuario con ID {id}");
            return Ok(user);
        }

        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateUser(User user, CancellationToken cancellationToken)
        {
            var created = await _userService.AddAsync(user, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateUser")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateUser(int id, User user, CancellationToken cancellationToken)
        {
            var updated = await _userService.UpdateAsync(user, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró un usuario con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteUser")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
        {
            var deleted = await _userService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró un usuario con ID {id}");
            return Ok(true);
        }
    }
}
