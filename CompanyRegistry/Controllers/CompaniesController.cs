using CompanyRegistry.Models;
using CompanyRegistry.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyRegistry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class CompaniesController : ControllerBase
    {

        private readonly CompaniesServices _services;

        public CompaniesController(CompaniesServices services)
        {
            _services = services;
        }

        // GET: api/<CompaniesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAllCompaniesAsync());
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _services.GetCompanyByIdAsync(id));
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public async Task<IActionResult> Post(Companies company)
        {
            try
            { 
                var createdCompany = await _services.AddCompanyAsync(company);
                return Ok(createdCompany);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
            
            
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Companies company)
        {
            try
            {
                await _services.AddCompanyAsync(company);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity (ex.Message);
            }
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _services.DeleteCompanyAsync(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}
