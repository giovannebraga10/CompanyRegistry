using CompanyRegistry.DTO;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public int CompanyTypeId { get; set; }
        public virtual CompanyTypes CompanyType { get; set; } = null!;
        public bool Active { get; set; } = true;
    }

    public static class CompaniesMapper
    {
        public static ResponseCompanyDTO ToDTO(this Companies c)
        {
            return new ResponseCompanyDTO
            {
                Id = c.Id,
                TradeName = c.TradeName,
                CompanyName = c.CompanyName,
                Cnpj = c.Cnpj,
                Active = c.Active,
                CompanyType = c.CompanyType
            };
        }

        public static Companies ToModel(this CreateCompanyDTO c)
        {
            return new Companies
            {
                TradeName = c.TradeName,
                CompanyName = c.CompanyName,
                Cnpj = c.Cnpj,
                CompanyTypeId = c.CompanyTypeId
            };
        }
    }
}
