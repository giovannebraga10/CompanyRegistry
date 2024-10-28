using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int CompanyType { get; set; }
        public bool Active { get; set; }


    }
}
