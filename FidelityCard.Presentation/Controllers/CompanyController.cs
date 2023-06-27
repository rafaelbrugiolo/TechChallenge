using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FidelityCard.Presentation.Controllers;

public class CompaniesController : Controller
{
    private readonly ICompanyService _CompanyService;

    public CompaniesController(ICompanyService companyService)
    {
        _CompanyService = companyService;
    }

    public ActionResult Index()
    {
        var companies = _CompanyService.GetAll().ToArray();
        return View(companies);
    }

	public ActionResult Details(Guid id)
    {
        var company = _CompanyService.GetById(id);
        return View(company);
    }

	public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CompanyRequestDto dto)
    {
        try
        {
            _CompanyService.Create(dto);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

	[HttpGet("Companies/Edit/{id}")]
	public ActionResult Edit(Guid id)
    {
        try
        {
            var company = _CompanyService.GetById(id);
            return View(company);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

	[HttpPost]
	[ValidateAntiForgeryToken]
    public ActionResult Edit(Guid id, CompanyRequestDto dto)
    {
        try
        {
			_CompanyService.Edit(id, dto);
            return RedirectToAction(nameof(Index));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

	[HttpGet("Companies/Delete/{id}")]
	public ActionResult Delete(Guid id)
    {
        try
        {
            var company = _CompanyService.GetById(id);
            return View(company);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

	[HttpPost]
	[ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(Guid id, CompanyRequestDto dto)
    {
        try
        {
			_CompanyService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

	[HttpGet("Companies/GetById/{id}")]
	public ActionResult GetById(Guid id)
	{
		try
		{
			var company = _CompanyService.GetById(id);
            return Content(company?.TradeName ?? string.Empty);
		}
		catch (ResourceNotFoundException ex)
		{
			return NotFound();
		}
	}
}
