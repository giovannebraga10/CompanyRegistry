using CompanyRegistry.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompanyRegistry.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.CompanyTypes.Any() && context.UserTypes.Any())
            {
                return;   // DB has been seeded
            }

            var companyTypes = new CompanyTypes[]
            {
                new CompanyTypes{Name="LTDA",Description="Limitada"},
                new CompanyTypes{Name="MEI",Description="Micro Empreendedor Individual"},
                new CompanyTypes{Name="SA",Description="Sociedade Anonima"},
                new CompanyTypes{Name="EIRELI",Description="Eireli"},
            };

            context.CompanyTypes.AddRange(companyTypes);
            context.SaveChanges();

            var userTypes = new UserTypes[]
            {
                new UserTypes{Name="Agencias",Description="Agencias"},
                new UserTypes{Name="Parceiros",Description="Parceiros"},
                new UserTypes{Name="Colaboradores",Description="Colaboradores internos"},
                new UserTypes{Name="Administradores",Description="Administradores"},
            };

            context.UserTypes.AddRange(userTypes);
            context.SaveChanges();

            var companies = new Companies[]
            {
                new Companies{TradeName="Google",CompanyName="Google LTDA",Cnpj="01234567891234",CompanyTypeId=1,Active=true},
                new Companies{TradeName="Microsoft",CompanyName="Microsoft SA",Cnpj="9876543210987",CompanyTypeId=3,Active=true}
            };

            context.Companies.AddRange(companies);
            context.SaveChanges();

            var users = new Users[]
            {
                new Users{Name="Giovanne",Email="giovanne@email.com",Cpf="12345678910",UserTypeId=3,CompanyId=1,Active=true},
                new Users{Name="Renan",Email="renan@email.com",Cpf="10987654321",UserTypeId=3,CompanyId=2,Active=true},
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
