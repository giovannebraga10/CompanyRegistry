using CompanyRegistry.Data.Repositories;
using CompanyRegistry.DTO;
using CompanyRegistry.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace CompanyRegistry.Services
{
    public class UsersServices
    {
        private readonly UsersRepository _repository;

        public UsersServices(UsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync(string? search)
        {
            return await _repository.GetAllAsync(search);
        }

        public async Task<Users?> GetUserByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Users?> AddUserAsync(Users user)
        {
            var userExits = await _repository.UserCpfExists(user.Cpf);
            
            if (userExits)
            {
                throw new InvalidOperationException("Ja existe um usuario com este Cpf");
            }

            var id = await _repository.AddAsync(user);

            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDTO user)
        {
            return await _repository.UpdateAsync(id, user);
        }

        public async Task DeleteUserById(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<bool> DisableById(int id)
        {
            return await _repository.DisableAsync(id);
        }

        public async Task<IEnumerable<Users>> GetAllByTypeAsync(int type)
        {
            return await _repository.GetAllByTypeAsync(type);
        }
    }
}