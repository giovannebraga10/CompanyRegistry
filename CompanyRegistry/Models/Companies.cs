using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyRegistry.Models
{
    [Table("Companies")]
    public class Companies
    {
        [Key]
        public int Id { get; set; } 
        public string TradeName { get; set; }
        public string CompanyName {  get; set; }
        public string Cnpj { get; set; }
        [JsonIgnore]
        public int CompanyTypeId { get; set; }
        public virtual CompanyTypes? CompanyType { get; set; } = null!;
        public bool Active { get; set; }


    }
}
