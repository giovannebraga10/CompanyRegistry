using CompanyRegistry.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CompanyRegistry.Data.Repositories
{
    public class UsersRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Users>> GetAllAsync(string? name, string? cpf)
        {
            var query = _context.Users;

            if (name == null && cpf == null)
            {
                return await query.ToListAsync();
            }
                return await query.Where(u => EF.Functions.ILike(u.Name, $"%{name}%") || EF.Functions.ILike(u.Cpf, $"%{cpf}%" )).ToListAsync();
        }

        public async Task<Users?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Users> AddAsync(Users user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync (Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UserCpfExists(string cpf) 
        {
            return await _context.Users.AnyAsync(u  => u.Cpf == cpf);
        }
    }
}
