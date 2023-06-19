using Microsoft.AspNetCore.Mvc;
using FidelityCard.Application.Common;
using FidelityCard.Application.Interfaces;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;

namespace FidelityCard.Presentation.Controllers;

public class UsersController : Controller
{
    private readonly IUserService _UserService;

    public UsersController(IUserService UserService)
    {
        _UserService = UserService;
    }

    // GET: UserController
    public ActionResult Index()
    {
        var people = _UserService.GetAll();
        return View(people);
    }

    // GET: UserController/Details/5
    public ActionResult Details(Guid id)
    {
        var user = _UserService.GetById(id);
        return View(user);
    }

    // GET: UserController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: UserController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(UserRequestDto userDto)
    {
        try
        {
            var file = Request.Form.Files["AvatarImage"];
            await _UserService.Create(userDto, file);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: UserController/Edit/5
    public ActionResult Edit(Guid id)
    {
        try
        {
            var user = _UserService.GetById(id);
            return View(user);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    // POST: UserController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Guid id, UserResponseDto viewModel)
    {
        try
        {
            var file = Request.Form.Files["AvatarImage"];
            _UserService.Edit(id, viewModel, file);
            return RedirectToAction(nameof(Index));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    // GET: UserController/Delete/5
    public ActionResult Delete(Guid id)
    {
        try
        {
            var user = _UserService.GetById(id);
            return View(user);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    // POST: UserController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Guid id, UserRequestDto userDto)
    {
        try
        {
            _UserService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }
}
