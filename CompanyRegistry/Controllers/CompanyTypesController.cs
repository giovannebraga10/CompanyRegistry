using CompanyRegistry.Models;
using CompanyRegistry.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyRegistry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypesController : ControllerBase
    {
        private readonly CompanyTypesServices _services;

        public CompanyTypesController(CompanyTypesServices services)
        {
            _services = services;
        }

        // GET: api/<CompanyTypesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok (await _services.GetAllCompanyTypesAsync());
        }

        // GET api/<CompanyTypesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
               return Ok (await _services.GetCompanyTypeByIdAsync(id));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        // POST api/<CompanyTypesController>
        [HttpPost]
        public async Task<IActionResult> Post(CompanyTypes company)
        {
            try
            {
                var createdCompanyType = await _services.AddCompanyTypeAsync(company);
                return Ok(createdCompanyType);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        // DELETE api/<CompanyTypesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _services.DeleteCompanyTypeAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}
