using CompanyRegistry.Models;

namespace CompanyRegistry.DTO
{
    public class ResponseCompanyDTO
    {
        public int Id { get; set; }
        public string TradeName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public CompanyTypes CompanyType { get; set; }
        public bool Active { get; set; }
    }
}
