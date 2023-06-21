namespace FidelityCard.Application.Dtos.Response;

public class CompanyResponseDto
{
    public Guid Id { get; set; }
	public string Cnpj { get; set; }
	public string CompanyName { get; set; }
	public string TradeName { get; set; }
	public bool IsRemoved { get; set; }
}