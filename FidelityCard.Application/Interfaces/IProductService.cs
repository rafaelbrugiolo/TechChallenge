using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;
using Microsoft.AspNetCore.Http;

namespace FidelityCard.Application.Interfaces;
public interface IProductService
{
    Task<Guid> Create(ProductRequestDto dto, IFormFile? file);
    ProductResponseDto GetById(Guid id);
    Task Edit(Guid id, ProductRequestDto dto, IFormFile? file);
    void DeleteById(Guid id);
    IEnumerable<ProductResponseDto> GetAll();
}
