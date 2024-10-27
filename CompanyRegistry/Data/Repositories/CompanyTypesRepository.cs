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

        public async Task GetAllAsync()
        {
            await _context.CompanyTypes.ToListAsync();
        }

        public async Task GetByIdAsync(int id)
        {
            await _context.CompanyTypes.FindAsync(id);
  
        }

        public async Task AddAsync(CompanyTypes companyType)
        {
            await _context.CompanyTypes.AddAsync(companyType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var companyType = await _context.CompanyTypes.FindAsync(id);
            _context.CompanyTypes.Remove(companyType);
        }
    }
}
