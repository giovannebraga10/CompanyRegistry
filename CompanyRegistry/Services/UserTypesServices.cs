using CompanyRegistry.Data.Repositories;
using CompanyRegistry.Models;

namespace CompanyRegistry.Services
{
    public class UserTypesServices
    {
        private readonly UserTypesRepository _repository;

        public UserTypesServices(UserTypesRepository repository)
        {
            _repository = repository;
        }

        public async Task GetAllUserTypes()
        {
            await _repository.GetAllAsync();
        }

        public async Task GetUserTypeById(int id)
        {
            await _repository.GetByIdAsync(id);
        }

        public async Task AddUserType(UserTypes userType)
        {
            await _repository.AddAsync(userType);
        }

        public async Task UpdateUserType(UserTypes userType)
        {
            await _repository.UpdateUserType(userType);
        }

        public async Task DeleteUserType(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
