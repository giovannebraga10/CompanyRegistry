﻿namespace CompanyRegistry.DTO
{
    public class PutCompany
    {
        public string? TradeName { get; set; }
        public string? CompanyName { get; set; }
        public string? Cnpj { get; set; }
        public int? CompanyTypeId { get; set; }
        public bool? Active { get; set; }
    }
}
