using Microsoft.AspNetCore.Http;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;

namespace FidelityCard.Application.Interfaces;
public interface IUserService
{
    Task<Guid> Create(UserRequestDto dto, IFormFile? file);
    UserResponseDto GetById(Guid id);
    Task Edit(Guid id, UserRequestDto dto, IFormFile? file);
    void DeleteById(Guid id);
    IEnumerable<UserResponseDto> GetAll();
}
