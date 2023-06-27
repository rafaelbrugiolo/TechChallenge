namespace FidelityCard.Application.Dtos.Response;
public class ProductResponseDto
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? PictureFileName { get; set; }
    public string? PictureContent { get; set; }

	public CompanyResponseDto Company { get; set; }
}
