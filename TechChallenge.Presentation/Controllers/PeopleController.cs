using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.Common;
using TechChallenge.Application.Dtos;
using TechChallenge.Application.Services;
using TechChallenge.Application.ViewModels;

namespace TechChallenge.Presentation.Controllers;

public class PeopleController : Controller
{
    private readonly IPersonService _personService;

    public PeopleController(IPersonService personService)
    {
        _personService = personService;
    }

    // GET: PeopleController
    public ActionResult Index()
    {
        var people = _personService.GetAllPeople();
        return View(people);
    }

    // GET: PeopleController/Details/5
    public ActionResult Details(Guid id)
    {
        var person = _personService.GetPersonById(id);
        return View(person);
    }

    // GET: PeopleController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PeopleController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(PersonDto dto)
    {
        try
        {
            var file = Request.Form.Files["AvatarImage"];
            await _personService.CreatePerson(dto, file);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PeopleController/Edit/5
    public ActionResult Edit(Guid id)
    {
        try
        {
            var person = _personService.GetPersonById(id);
            return View(person);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    // POST: PeopleController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Guid id, PersonViewModel viewModel)
    {
        try
        {
            var file = Request.Form.Files["AvatarImage"];
            _personService.EditPerson(id, viewModel, file);
            return RedirectToAction(nameof(Index));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    // GET: PeopleController/Delete/5
    public ActionResult Delete(Guid id)
    {
        try
        {
            var person = _personService.GetPersonById(id);
            return View(person);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    // POST: PeopleController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Guid id, PersonDto dto)
    {
        try
        {
            _personService.DeletePersonById(id);
            return RedirectToAction(nameof(Index));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }
}
