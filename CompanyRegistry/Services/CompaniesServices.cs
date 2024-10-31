using CompanyRegistry.Models;
using CompanyRegistry.Data.Repositories;
using CompanyRegistry.DTO;

namespace CompanyRegistry.Services
{
    public class CompaniesServices 
    {
        private readonly CompaniesRepository _repository;

        public CompaniesServices(CompaniesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Companies>> GetAllCompaniesAsync(string? name)
        {
            return await _repository.GetAllAsync(name);
        }

        public async Task<Companies?> GetCompanyByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Companies> AddCompanyAsync(Companies company)
        {
            return await _repository.AddAsync(company);
        }

        public async Task<bool> UpdateCompanyAsync(int id, UpdateCompanyDTO company)
        {
            return await _repository.UpdateAsync(id, company);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<bool> DisableById(int id)
        {
            return await _repository.DisableAsync(id);
        }

        public async Task<IEnumerable<Companies>> GetAllByTypeAsync(int type)
        {
            return await _repository.GetAllByTypeAsync(type);
        }
    }
}
