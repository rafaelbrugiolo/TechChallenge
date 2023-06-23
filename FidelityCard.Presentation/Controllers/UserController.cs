using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FidelityCard.Presentation.Controllers;

public class UsersController : Controller
{
    private readonly IUserService _UserService;
    private readonly ICompanyService _CompanyService;

    public UsersController(IUserService UserService, ICompanyService CompanyService)
    {
        _UserService = UserService;
        _CompanyService = CompanyService;
    }

    public ActionResult Index()
    {
        var people = _UserService.GetAll().ToArray();
        return View(people);
    }

	public ActionResult Details(Guid id)
    {
        var user = _UserService.GetById(id);
        return View(user);
    }

	public ActionResult Create()
    {
        var companies = _CompanyService.GetAll().ToArray();

        return View(companies);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(UserRequestDto dto)
    {
        try
        {
            var file = Request.Form.Files["AvatarImage"];
            await _UserService.Create(dto, file);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

	[HttpGet("Users/Edit/{id}")]
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

	[HttpPost]
	[ValidateAntiForgeryToken]
    public ActionResult Edit(Guid id, UserRequestDto dto)
    {
        try
        {
            var file = Request.Form.Files["AvatarImage"];
            _UserService.Edit(id, dto, file);
            return RedirectToAction(nameof(Index));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

	[HttpGet("Users/Delete/{id}")]
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

	[HttpPost]
	[ValidateAntiForgeryToken]
    public ActionResult Delete(Guid id, UserRequestDto dto)
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
