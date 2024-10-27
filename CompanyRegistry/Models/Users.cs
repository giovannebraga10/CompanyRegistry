namespace CompanyRegistry.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Cpf { get; set; }
        public int UserType { get; set; }
        public int Company { get; set; }
        public bool Partner { get; set; }
        public bool Active { get; set; }
    }
}
