using CompanyRegistry.Data.Repositories;
using CompanyRegistry.Models;

namespace CompanyRegistry.Services
{
    public class CompanyTypesServices
    {
        private readonly CompanyTypesRepository _repository;

        public CompanyTypesServices(CompanyTypesRepository repository)
        {
            _repository = repository;
        }

        public async Task GetAllCompanyTypesAsync()
        {
            await _repository.GetAllAsync();
        }

        public async Task<CompanyTypes> GetCompanyTypeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<CompanyTypes> AddCompanyTypeAsync (CompanyTypes companyType)
        {
           return await _repository.AddAsync(companyType);
        }

        public async Task DeleteCompanyTypeAsync (int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
