namespace FidelityCard.Application.Dtos.Response;
public class CustomerResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; }
    public string ContactPhone { get; set; }
}
