using CompanyRegistry.Models;
using CompanyRegistry.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyRegistry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly UserTypesServices _services;
        public UserTypesController(UserTypesServices service)
        {
            _services = service;
        }

        // GET: api/<UserTypesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok (await _services.GetAllUserTypes());
        }

        // GET api/<UserTypesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok (await _services.GetUserTypeById(id));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        // POST api/<UserTypesController>
        [HttpPost]
        public async Task<IActionResult> Post(UserTypes userType)
        {
            try
            {
                var createdUserType = await _services.AddUserType(userType);
                return Ok(createdUserType);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
            
        }

        // PUT api/<UserTypesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UserTypes userType)
        {
            try
            {
                await _services.UpdateUserType(userType);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
            
        }

        // DELETE api/<UserTypesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _services.DeleteUserType(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
            
        }
    }
}
