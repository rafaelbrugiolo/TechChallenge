using Microsoft.AspNetCore.Http;
using FidelityCard.Application.Dtos;
using FidelityCard.Application.ViewModels;

namespace FidelityCard.Application.Services;
public interface IUserService
{
    Task<Guid> CreateUser(UserDto dto, IFormFile? file);
    UserViewModel GetUserById(Guid id);
    Task EditUser(Guid id, UserViewModel dto, IFormFile? file);
    void DeleteUserById(Guid id);
    IEnumerable<UserViewModel> GetAllUser();
}
