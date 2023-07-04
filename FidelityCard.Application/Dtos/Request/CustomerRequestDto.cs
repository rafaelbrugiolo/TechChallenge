namespace FidelityCard.Application.Dtos.Request;
public class CustomerRequestDto
{
    public string Name { get; set; }
    public string? Email { get; set; }
    public DateTime? Birthdate { get; set; }
    public string? ContactPhone { get; set; }
}
