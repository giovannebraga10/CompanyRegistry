using CompanyRegistry.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyRegistry.Data.Repositories
{
    public class CompanyTypesRepository
    {
        private readonly AppDbContext _context;

        public CompanyTypesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyTypes>> GetAllAsync()
        {
            return await _context.CompanyTypes.ToListAsync();
        }

        public async Task<CompanyTypes> GetByIdAsync(int id)
        {
            return await _context.CompanyTypes.FindAsync(id);
  
        }

        public async Task<CompanyTypes> AddAsync(CompanyTypes companyType)
        {
            var result =  await _context.CompanyTypes.AddAsync(companyType);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var companyType = await _context.CompanyTypes.FindAsync(id);
            _context.CompanyTypes.Remove(companyType);
        }

    }
}
