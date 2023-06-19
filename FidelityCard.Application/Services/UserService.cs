using Microsoft.AspNetCore.Http;
using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos;
using FidelityCard.Application.ViewModels;
using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;

namespace FidelityCard.Application.Services;

public class UserService : IUserService
{
    private const string UserContainer = "userscontainer";
    private readonly IStorage _blobStorage;
    private readonly IUserRepository _repository;

    public UserService(IStorage blobStorage, IUserRepository repository)
    {
        _blobStorage = blobStorage;
        _repository = repository;
    }

    public async Task<Guid> CreateUser(UserDto dto, IFormFile? file)
    {
        var fileName = await UploadAvatar(file);
        var user = new User
        {
            Name = dto.Name,
            AvatarFileName = fileName
        };
        _repository.Insert(user);
        _repository.SaveChanges();

        return user.Id;
    }

    public UserViewModel GetUserById(Guid id)
    {
        var user = _repository.Read(id);
        if (user is null)
            throw new ResourceNotFoundException($"User {id} not found.");
        
        return new UserViewModel { Id = user.Id, Name = user.Name };
    }

    public async Task EditUser(Guid id, UserViewModel viewModel, IFormFile? file)
    {
        var user = _repository.Read(id);
        if (user is null)
            throw new ResourceNotFoundException($"User {id} not found.");

        if (!string.IsNullOrWhiteSpace(user.AvatarFileName))
            _blobStorage.DeleteFile(UserContainer, user.AvatarFileName);

        var fileName = await UploadAvatar(file);

        user.Name = viewModel.Name;
        user.AvatarFileName = fileName;

        _repository.Update(user);
        _repository.SaveChanges();
    }

    public void DeleteUserById(Guid id)
    {
        var user = _repository.Read(id);
        if (user is null)
            throw new ResourceNotFoundException($"User {id} not found.");

        if (!string.IsNullOrWhiteSpace(user.AvatarFileName))
            _blobStorage.DeleteFile(UserContainer, user.AvatarFileName);

        _repository.Delete(id);
        _repository.SaveChanges();
    }

    public IEnumerable<UserViewModel> GetAllUser()
    {
        foreach (var user in _repository.List())
            yield return new UserViewModel { Id = user.Id, Name = user.Name };
    }

    private async Task<string?> UploadAvatar(IFormFile? file)
    {
        if (file is null)
            return null;

        var extension = Path.GetExtension(file.FileName).Replace(".", "");
        var fileName = await _blobStorage.UploadFile(UserContainer, file.OpenReadStream(), extension);
        return fileName;
    }
}