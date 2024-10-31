using CompanyRegistry.DTO;
using CompanyRegistry.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompanyRegistry.Data.Repositories
{
    public class UsersRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Users>> GetAllAsync(string? search)
        {
            var query = _context.Users.Include(u => u.UserType).Include(u => u.Company).ThenInclude(c => c.CompanyType).Where(u => u.Active);

            if (search == null)
            {
                return await query.ToListAsync();
            }
                return await query.Where(u => EF.Functions.ILike(u.Name, $"%{search}%") || EF.Functions.ILike(u.Cpf, $"%{search}%")).ToListAsync();
        }

        public async Task<Users?> GetByIdAsync(int id)
        {
            return await _context.Users.Include(u => u.UserType).Include(u => u.Company).ThenInclude(c => c.CompanyType).Where(u => u.Active && u.Id == id).SingleOrDefaultAsync();
        }

        public async Task<int> AddAsync(Users user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> UpdateAsync (int id, UpdateUserDTO user)
        {
            var result = await _context.Users.FindAsync(id);

            if (result == null)
            {
                return false;
            }

            _context.Entry(result).CurrentValues.SetValues(user);

            var rows = await _context.SaveChangesAsync();

            return Convert.ToBoolean(rows);
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

        public async Task<IEnumerable<Users>> GetAllByTypeAsync(int type)
        {
            return await _context.Users.Include(c => c.UserType).Include(u => u.Company).ThenInclude(c => c.CompanyType).Where(c => c.Active && c.UserTypeId == type).ToListAsync();
        }

        public async Task<bool> DisableAsync(int id)
        {
            var result = await _context.Users.FindAsync(id);

            if (result == null)
            {
                return false;
            }

            _context.Entry(result).CurrentValues.SetValues(new { Active = false });

            var rows = await _context.SaveChangesAsync();

            return Convert.ToBoolean(rows);
        }
    }
}
