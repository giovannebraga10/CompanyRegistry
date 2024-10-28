using CompanyRegistry.Data.Repositories;
using CompanyRegistry.Models;


namespace CompanyRegistry.Services
{
    public class UsersServices
    {
        private readonly UsersRepository _repository;

        public UsersServices(UsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Users?> GetUserByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Users> AddUserAsync(Users user)
        {
           return await _repository.AddAsync(user);
        }

        public async Task UpdateUserAsync(Users user)
        {
            await _repository.UpdateAsync(user);
        }

        public async Task DeleteUserById(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}