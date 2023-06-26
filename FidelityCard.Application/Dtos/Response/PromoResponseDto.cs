namespace FidelityCard.Application.Dtos.Response;
public class PromoResponseDto
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageFileName { get; set; }
    public string? ImageContent { get; set; }
	public int TimesToPrize { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }

	public UserResponseDto User { get; set; }
	public ProductResponseDto Product { get; set; }
	public CompanyResponseDto Company { get; set; }
}
