using Microsoft.AspNetCore.Http;
using TechChallenge.Application.Dtos;
using TechChallenge.Application.ViewModels;

namespace TechChallenge.Application.Services;
public interface IPersonService
{
    Task<Guid> CreatePerson(PersonDto dto, IFormFile? file);
    PersonViewModel GetPersonById(Guid id);
    Task EditPerson(Guid id, PersonViewModel dto, IFormFile? file);
    void DeletePersonById(Guid id);
    IEnumerable<PersonViewModel> GetAllPeople();
}
