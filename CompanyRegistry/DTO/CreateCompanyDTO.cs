namespace CompanyRegistry.DTO
{
    public class CreateCompanyDTO
    {
        public string TradeName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public int CompanyTypeId { get; set; }
    }
}
