using CompanyRegistry.DTO;
using CompanyRegistry.Models;
using CompanyRegistry.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll([FromQuery] string? name)
        {
            var companies = await _services.GetAllCompaniesAsync(name);
            return Ok(companies.Select(c => c.ToDTO()));
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await _services.GetCompanyByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company.ToDTO());
        }

        // GET api/<CompaniesController>/types/5
        [HttpGet("types/{typeId}")]
        public async Task<IActionResult> GetAllByType(int typeId)
        {
            var companies = await _services.GetAllByTypeAsync(typeId);

            return Ok(companies.Select(c => c.ToDTO()));
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCompanyDTO company)
        {
            try
            { 
                var createdCompany = await _services.AddCompanyAsync(company.ToModel());

                return Ok(createdCompany.ToDTO());
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
            
            
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCompanyDTO company)
        {
            try
            {
                var updated = await _services.UpdateCompanyAsync(id, company);

                if(!updated)
                {
                    return NotFound();
                }

                return NoContent();
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

        // DELETE api/<CompaniesController>/disable/5
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
