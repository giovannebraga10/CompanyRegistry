﻿using CompanyRegistry.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyRegistry.Data.Repositories
{
    public class UserTypesRepository
    {
        private readonly AppDbContext _context;

        public UserTypesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserTypes>> GetAllAsync()
        {
            return await _context.UserTypes.ToListAsync();
        }

        public async Task<UserTypes> GetByIdAsync(int id)
        {
          return await _context.UserTypes.FindAsync(id);
        }

        public async Task<UserTypes> AddAsync(UserTypes userType)
        {
            var result = await _context.UserTypes.AddAsync(userType);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        
        public async Task UpdateUserType(UserTypes userType)
        {
            _context.UserTypes.Update(userType);
            await _context.SaveChangesAsync();
            
        }
        public async Task DeleteAsync(int id)
        {
            var userTypes = await _context.UserTypes.FindAsync(id);
            _context.UserTypes.Remove(userTypes);
            await _context.SaveChangesAsync();            
        }
    }
}
