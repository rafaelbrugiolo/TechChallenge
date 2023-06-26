using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;
using Microsoft.AspNetCore.Http;

namespace FidelityCard.Application.Interfaces;
public interface IPromoService
{
    Task<Guid> Create(PromoRequestDto dto, IFormFile? file);
    Task<PromoResponseDto> GetById(Guid id);
    Task Edit(Guid id, PromoRequestDto dto, IFormFile? file);
    void DeleteById(Guid id);
    IEnumerable<PromoResponseDto> GetAll();
}
