using CompanyRegistry.DTO;
using CompanyRegistry.Models;
using CompanyRegistry.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyRegistry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       private readonly UsersServices _services;

        public UsersController(UsersServices services)
        {
            _services = services;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search)
        {
            var users = await _services.GetAllUsersAsync(search);

            return Ok (users.Select(u => u.ToDTO()));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _services.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok (user.ToDTO());
        }

        // GET api/<UserController>/types/5
        [HttpGet("types/{typeId}")]
        public async Task<IActionResult> GetAllByType(int typeId)
        {
            var users = await _services.GetAllByTypeAsync(typeId);

            return Ok(users.Select(u => u.ToDTO()));
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserDTO user)
        {
            try
            {
                var createdUser = await _services.AddUserAsync(user.ToModel());

                return Ok(createdUser?.ToDTO());
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserDTO user)
        {
            try
            {
                var updated = await _services.UpdateUserAsync(id, user);

                if (!updated)
                {
                    return  UnprocessableEntity();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _services.DeleteUserById(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
            
        }

        // DELETE api/<UserController>/disable/5
        [HttpDelete("disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                var disabled = await _services.DisableById(id);

                if (disabled)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}
