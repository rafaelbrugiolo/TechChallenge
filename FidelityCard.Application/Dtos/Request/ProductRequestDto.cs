namespace FidelityCard.Application.Dtos.Request;
public class ProductRequestDto
{
    public Guid CompanyId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? PictureFileName { get; set; }
}
