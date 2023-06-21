using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;

namespace FidelityCard.Application.Interfaces;
public interface ICustomerService
{
    Guid Create(CustomerRequestDto dto);
    CustomerResponseDto GetById(Guid id);
    void Edit(Guid id, CustomerRequestDto dto);
    void DeleteById(Guid id);
    IEnumerable<CustomerResponseDto> GetAll();
}
