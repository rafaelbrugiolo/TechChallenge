namespace FidelityCard.Domain.Entities;

public class Product : BaseEntity
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? PictureFileName { get; set; }
}