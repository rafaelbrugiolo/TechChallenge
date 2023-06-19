using Microsoft.AspNetCore.Mvc;
using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos;
using FidelityCard.Application.Services;
using FidelityCard.Application.ViewModels;

namespace FidelityCard.Presentation.Controllers;

public class UsersController : Controller
{
    private readonly IUserService _UserService;

    public UsersController(IUserService UserService)
    {
        _UserService = UserService;
    }

    // GET: PeopleController
    public ActionResult Index()
    {
        var people = _UserService.GetAllUser();
        return View(people);
    }

    // GET: PeopleController/Details/5
    public ActionResult Details(Guid id)
    {
        var user = _UserService.GetUserById(id);
        return View(user);
    }

    // GET: PeopleController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PeopleController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(UserDto userDto)
    {
        try
        {
            var file = Request.Form.Files["AvatarImage"];
            await _UserService.CreateUser(userDto, file);

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
            var user = _UserService.GetUserById(id);
            return View(user);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    // POST: PeopleController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Guid id, UserViewModel viewModel)
    {
        try
        {
            var file = Request.Form.Files["AvatarImage"];
            _UserService.EditUser(id, viewModel, file);
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
            var user = _UserService.GetUserById(id);
            return View(user);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    // POST: PeopleController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Guid id, UserDto userDto)
    {
        try
        {
            _UserService.DeleteUserById(id);
            return RedirectToAction(nameof(Index));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }
}
