using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;
using FidelityCard.Application.Interfaces;
using FidelityCard.Application.Services;
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

    public ActionResult Details(Guid id)
    {
        var promo = _PromoService.GetById(id);
        return View(promo);
    }
    public ActionResult Create()
    {
        dynamic 
        List<CompanyResponseDto> companies = _CompanyService.GetAll().ToList();
        List<UserResponseDto> users = _UserService.GetAll().ToList();

        return View(new CompaniesUsers { Companies = companies, Users = users});
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

    public class CompaniesUsers
    {
		public List<CompanyResponseDto> Companies { get; set; }
		public List<UserResponseDto> Users { get; set; }
    }

}
