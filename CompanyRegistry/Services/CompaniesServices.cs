using CompanyRegistry.Models;
using CompanyRegistry.Data.Repositories;

namespace CompanyRegistry.Services
{
    public class CompaniesService 
    {
        private readonly CompaniesRepository _repository;

        public CompaniesService(CompaniesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Companies>> GetAllCompaniesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Companies?> GetCompanyByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddCompanyAsync(Companies company)
        {
            await _repository.AddAsync(company);
        }

        public async Task UpdateCompanyAsync(Companies company)
        {
            await _repository.UpdateAsync(company);
        }
    }
}
