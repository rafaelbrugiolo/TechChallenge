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
        ViewBag.Users = _UserService.GetAll().ToArray(); ;
        ViewBag.Companies = _CompanyService.GetAll().ToArray(); ;
        return View();
    }

	public async Task<ActionResult> DetailsAsync(Guid id)
    {
        var user = await _UserService.GetByIdWithCompany(id);
        return View(user);
    }

	public ActionResult Create()
    {
        var companies = _CompanyService.GetAll().ToArray();
        ViewBag.Companies = companies;
        return View();
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
            var user = _UserService.GetByIdWithCompany(id);
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
            var user = _UserService.GetByIdWithCompany(id);
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
