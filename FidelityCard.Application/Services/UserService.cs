using Microsoft.AspNetCore.Http;
using FidelityCard.Application.Common;
using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;
using FidelityCard.Application.Interfaces;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;
using AutoMapper;

namespace FidelityCard.Application.Services;

public class UserService : IUserService
{
    private const string UsersContainer = "users";
    private readonly IStorage _blobStorage;
    private readonly IUserRepository _repository;
	private readonly IMapper _mapper;

	public UserService(IStorage blobStorage, IUserRepository repository, IMapper mapper)
    {
        _blobStorage = blobStorage;
        _repository = repository;
		_mapper = mapper;
	}

    public async Task<Guid> Create(UserRequestDto dto, IFormFile? file)
    {
        var fileName = await UploadAvatar(file);
        
        var user = _mapper.Map<User>(dto);
        user.AvatarFileName = fileName;

        _repository.Insert(user);
        _repository.SaveChanges();

        return user.Id;
    }

    public UserResponseDto GetById(Guid id)
    {
        var user = _repository.Read(id);
        if (user is null)
            throw new ResourceNotFoundException($"User {id} not found.");
        
        return _mapper.Map<UserResponseDto>(user);
	}

    public async Task Edit(Guid id, UserRequestDto dto, IFormFile? file)
    {
        var user = _repository.Read(id);
        if (user is null)
            throw new ResourceNotFoundException($"User {id} not found.");

        if (!string.IsNullOrWhiteSpace(user.AvatarFileName))
            _blobStorage.DeleteFile(UsersContainer, user.AvatarFileName);

        var fileName = await UploadAvatar(file);

        user.Name = dto.Name;
        user.AvatarFileName = fileName;

        _repository.Update(user);
        _repository.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        var user = _repository.Read(id);
        if (user is null)
            throw new ResourceNotFoundException($"User {id} not found.");

        if (!string.IsNullOrWhiteSpace(user.AvatarFileName))
            _blobStorage.DeleteFile(UsersContainer, user.AvatarFileName);

        _repository.Delete(id);
        _repository.SaveChanges();
    }

    public IEnumerable<UserResponseDto> GetAll()
    {
        foreach (var user in _repository.List())
            yield return _mapper.Map<UserResponseDto>(user);
	}

    private async Task<string?> UploadAvatar(IFormFile? file)
    {
        if (file is null)
            return null;

        var extension = Path.GetExtension(file.FileName).Replace(".", "");
        var fileName = await _blobStorage.UploadFile(UsersContainer, file.OpenReadStream(), extension);
        return fileName;
    }
}