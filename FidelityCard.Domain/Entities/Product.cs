namespace FidelityCard.Domain.Entities;

public class Product : BaseEntity
{
    public Guid CompanyId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? PictureFileName { get; set; }

    public virtual Company Company { get; set; }
}