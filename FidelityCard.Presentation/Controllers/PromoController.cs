using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FidelityCard.Presentation.Controllers;

public class PromosController : Controller
{
    private readonly IPromoService _PromoService;
    private readonly IProductService _ProductService;


	public PromosController(IPromoService PromoService, IProductService productService)
	{
		_PromoService = PromoService;
		_ProductService = productService;
	}

	public ActionResult Index()
    {
        var promos = _PromoService.GetAll().ToArray();
        return View(promos);
    }

    public async Task<ActionResult> DetailsAsync(Guid id)
    {
        var promo = await _PromoService.GetByIdWithCompanyUserProduct(id);
        return View(promo);
    }
    public ActionResult Create()
    {
        var products = _ProductService.GetAll().ToList();
        ViewData[nameof(products)] = products;
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
    public async Task<ActionResult> EditAsync(Guid id)
    {
        try
        {
            var promo = await _PromoService.GetByIdWithCompanyUserProduct(id);
            return View(promo);
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Guid id, PromoRequestDto dto)
    {
        try
        {
            var file = Request.Form.Files["AvatarImage"];
            await _PromoService.Edit(id, dto, file);
            return RedirectToAction(nameof(Index));
        }
        catch (ResourceNotFoundException ex)
        {
            return NotFound();
        }
    }

    [HttpGet("Promos/Delete/{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            var user = await _PromoService.GetByIdWithCompanyUserProduct(id);
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
}
