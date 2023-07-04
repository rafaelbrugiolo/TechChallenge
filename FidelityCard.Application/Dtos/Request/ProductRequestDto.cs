namespace FidelityCard.Application.Dtos.Request;
public class ProductRequestDto
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? PictureFileName { get; set; }
}
