using Microsoft.AspNetCore.Http;
using TechChallenge.Application.Common;
using TechChallenge.Application.Dtos;
using TechChallenge.Application.ViewModels;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Services;

public class PersonService : IPersonService
{
    private const string personContainer = "peoplecontainer";
    private readonly IStorage _blobStorage;
    private readonly IPersonRepository _repository;

    public PersonService(IStorage blobStorage, IPersonRepository repository)
    {
        _blobStorage = blobStorage;
        _repository = repository;
    }

    public async Task<Guid> CreatePerson(PersonDto dto, IFormFile? file)
    {
        var fileName = await UploadAvatar(file);
        var person = new Person
        {
            Name = dto.Name,
            Birthdate = dto.Birthdate,
            AvatarFileName = fileName
        };
        _repository.Insert(person);
        _repository.SaveChanges();

        return person.Id;
    }

    public PersonViewModel GetPersonById(Guid id)
    {
        var person = _repository.Read(id);
        if (person is null)
            throw new ResourceNotFoundException($"Person {id} not found.");
        
        return new PersonViewModel { Id = person.Id, Name = person.Name, Birthdate = person.Birthdate };
    }

    public async Task EditPerson(Guid id, PersonViewModel viewModel, IFormFile? file)
    {
        var person = _repository.Read(id);
        if (person is null)
            throw new ResourceNotFoundException($"Person {id} not found.");

        if (!string.IsNullOrWhiteSpace(person.AvatarFileName))
            _blobStorage.DeleteFile(personContainer, person.AvatarFileName);

        var fileName = await UploadAvatar(file);

        person.Name = viewModel.Name;
        person.Birthdate = viewModel.Birthdate;
        person.AvatarFileName = fileName;

        _repository.Update(person);
        _repository.SaveChanges();
    }

    public void DeletePersonById(Guid id)
    {
        var person = _repository.Read(id);
        if (person is null)
            throw new ResourceNotFoundException($"Person {id} not found.");

        if (!string.IsNullOrWhiteSpace(person.AvatarFileName))
            _blobStorage.DeleteFile(personContainer, person.AvatarFileName);

        _repository.Delete(id);
        _repository.SaveChanges();
    }

    public IEnumerable<PersonViewModel> GetAllPeople()
    {
        foreach (var person in _repository.List())
            yield return new PersonViewModel { Id = person.Id, Name = person.Name, Birthdate = person.Birthdate };
    }

    private async Task<string?> UploadAvatar(IFormFile? file)
    {
        if (file is null)
            return null;

        var extension = Path.GetExtension(file.FileName).Replace(".", "");
        var fileName = await _blobStorage.UploadFile(personContainer, file.OpenReadStream(), extension);
        return fileName;
    }
}