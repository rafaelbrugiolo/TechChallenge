using Microsoft.AspNetCore.Http;
using FidelityCard.Application.Dtos;
using FidelityCard.Application.ViewModels;

namespace FidelityCard.Application.Interfaces;
public interface ICompanyService
{
    Task<Guid> Create(UserDto dto, IFormFile? file);
    UserViewModel GetById(Guid id);
    Task Edit(Guid id, UserViewModel dto, IFormFile? file);
    void DeleteById(Guid id);
    IEnumerable<UserViewModel> GetAll();
}
