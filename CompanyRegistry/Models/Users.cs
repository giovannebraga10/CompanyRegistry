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
        [JsonIgnore]
        public int UserTypeId { get; set; }
        public virtual UserTypes UserType { get; set; } = null!;
        [JsonIgnore]
        public int CompanyId { get; set; }
        public virtual Companies Company { get; set; } = null!;
        public bool Partner { get; set; } = false;
        public bool Active { get; set; } = true;
    }
}
