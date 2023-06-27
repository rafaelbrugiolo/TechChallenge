using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;
using FidelityCard.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace FidelityCard.Presentation.Controllers;

public class PromosController : Controller
{
    private readonly IPromoService _PromoService;
    private readonly ICompanyService _CompanyService;
    private readonly IUserService _UserService;


	public PromosController(IPromoService PromoService, ICompanyService CompanyService, IUserService userService)
	{
		_PromoService = PromoService;
		_CompanyService = CompanyService;
		_UserService = userService;
	}

	public ActionResult Index()
    {
        var promos = _PromoService.GetAll().ToArray();
        return View(promos);
    }

    public async Task<ActionResult> DetailsAsync(Guid id)
    {
        var promo = await _PromoService.GetById(id);
        return View(promo);
    }
    public ActionResult Create()
    { 
        var companies = _CompanyService.GetAll().ToArray();
        var users = _UserService.GetAll().ToArray();

        ViewBag.Companies = companies;
        ViewBag.Users = users;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(PromoRequestDto dto)
    {
        try
        {
            var file = Request.Form.Files["AvatarImage"];
            await _PromoService.Create(dto, file);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    [HttpGet("Promos/Edit/{id}")]
    public ActionResult Edit(Guid id)
    {
        try
        {
            var promo = _PromoService.GetById(id);
            return View(promo);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Guid id, PromoRequestDto dto)
    {
        try
        {
            var file = Request.Form.Files["AvatarImage"];
            _PromoService.Edit(id, dto, file);
            return RedirectToAction(nameof(Index));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    [HttpGet("Promos/Delete/{id}")]
    public ActionResult Delete(Guid id)
    {
        try
        {
            var user = _PromoService.GetById(id);
            return View(user);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Guid id, PromoRequestDto dto)
    {
        try
        {
            _PromoService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }
	public ActionResult GetCompanyName(Guid companyID)
	{
		var company = _CompanyService.GetById(companyID);
		return Content(company?.CompanyName ?? string.Empty);
	}
}
