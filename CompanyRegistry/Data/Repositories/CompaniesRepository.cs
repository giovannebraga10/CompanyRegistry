using CompanyRegistry.Models;
using Microsoft.EntityFrameworkCore;
using CompanyRegistry.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CompanyRegistry.DTO;
using System.Net;

namespace CompanyRegistry.Data.Repositories
{
    public class CompaniesRepository
    {
        private readonly AppDbContext _context;

        public CompaniesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Companies>> GetAllAsync(string? name)
        {
            var query = _context.Companies.Include(c => c.CompanyType).Where(c => c.Active == true);

            if (name == null) 
            {
                return await query.ToListAsync();
            }
            return await query.Where(c => EF.Functions.ILike(c.TradeName, $"%{name}%") || EF.Functions.ILike(c.CompanyName, $"%{name}%")).ToListAsync();
        }

        public async Task<Companies?> GetByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<Companies> AddAsync(Companies company)
        {
            var result = await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> UpdateAsync(int id, PutCompany company)
        {
            var result = await _context.Companies.FindAsync(id);

            if(result == null)
            {
                return false;
            }

            _context.Entry(result).CurrentValues.SetValues(company);

            var rows = await _context.SaveChangesAsync();

            return Convert.ToBoolean(rows);
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Companies>> GetAllByTypeAsync(int type)
        {
            return await _context.Companies.Include(c => c.CompanyType).Where(c => c.Active == true && c.CompanyTypeId == type).ToListAsync();
        }

    }
}
