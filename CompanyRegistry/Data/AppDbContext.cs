using CompanyRegistry.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CompanyRegistry.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<CompanyTypes> CompanyTypes { get; set; }
        public DbSet<UserTypes> UserTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
           // Adicionado Constraint para valor unico na coluna Cnpj, em cenarios que o banco de dados é compartilhado com outras aplicações 
            builder.Entity<Companies>(entity => {
                entity.HasIndex(e => e.Cnpj).IsUnique();
            });
        }


    }
}
