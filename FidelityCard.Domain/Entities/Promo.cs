namespace FidelityCard.Domain.Entities;

public class Promo : BaseEntity
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageFileName { get; set; }
    public int TimesToPrize { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public virtual Company Company { get; set; }
    public virtual User User { get; set; }
    public virtual Product Product { get; set; }
}