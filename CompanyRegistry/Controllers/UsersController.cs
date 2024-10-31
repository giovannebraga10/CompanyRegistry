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
        public async Task<IActionResult> GetAll([FromQuery] string ? name, string? cpf)
        {
            return Ok (await _services.GetAllUsersAsync(name, cpf));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok (await _services.GetUserByIdAsync(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(Users user)
        {
            try
            {
                var createdUser = await _services.AddUserAsync(user);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Users user)
        {
            try
            {
                await _services.UpdateUserAsync(user);
                return Ok();
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
