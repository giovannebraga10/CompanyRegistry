using CompanyRegistry.Models;

namespace CompanyRegistry.DTO
{
    public class ResponseUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Cpf { get; set; }
        public UserTypes UserType { get; set; } = null!;
        public ResponseCompanyDTO? Company { get; set; } = null!;
        public bool? Partner { get; set; }
        public bool Active { get; set; }
    }
}
