namespace FidelityCard.Domain.Entities;

public class Promo : BaseEntity
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageFileName { get; set; }
    public int TimesToPrize { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public virtual Product Product { get; set; }
}