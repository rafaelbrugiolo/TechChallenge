namespace FidelityCard.Domain.Entities;

public class Company : BaseEntity
{
    public string Cnpj { get; set; }
    public string CompanyName { get; set; }
    public string TradeName { get; set; }
    public bool IsRemoved { get; set; }
}