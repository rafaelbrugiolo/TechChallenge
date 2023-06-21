using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;

namespace FidelityCard.Application.Interfaces;
public interface ICompanyService
{
    Guid Create(CompanyRequestDto dto);
	CompanyResponseDto GetById(Guid id);
    void Edit(Guid id, CompanyRequestDto dto);
    void DeleteById(Guid id);
    IEnumerable<CompanyResponseDto> GetAll();
}