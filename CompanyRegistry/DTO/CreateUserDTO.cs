using CompanyRegistry.Models;

namespace CompanyRegistry.DTO
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Cpf { get; set; }
        public int UserTypeId { get; set; }
        public int? CompanyId { get; set; }
        public bool? Partner { get; set; }
    }
}
