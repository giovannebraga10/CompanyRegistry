using CompanyRegistry.DTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CompanyRegistry.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Cpf { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserTypes UserType { get; set; } = null!;
        public int? CompanyId { get; set; }
        public virtual Companies? Company { get; set; } = null!;
        public bool? Partner { get; set; } = false;
        public bool Active { get; set; } = true;
    }

    public static class UsersMapper
    {
        public static ResponseUserDTO ToDTO(this Users u)
        {
            return new ResponseUserDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Cpf = u.Cpf,
                Active = u.Active,
                Partner = u.Partner,
                UserType = u.UserType,
                Company = u.Company?.ToDTO(),
            };
        }

        public static Users ToModel(this CreateUserDTO u)
        {
            return new Users
            {
                Name = u.Name,
                Email = u.Email,
                Cpf = u.Cpf,
                Partner = u.Partner,
                UserTypeId = u.UserTypeId,
                CompanyId = u.CompanyId
            };
        }
    }
}
