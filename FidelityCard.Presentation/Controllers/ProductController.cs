using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FidelityCard.Presentation.Controllers;

public class ProductsController : BaseController
{
	private readonly IProductService _ProductService;

	public ProductsController(IProductService ProductService)
	{
		_ProductService = ProductService;
	}

	public ActionResult Index()
	{
		var products = _ProductService.GetAll().ToArray();
		return View(products);
	}

	public ActionResult DetailsAsync(Guid id)
	{
		var product = _ProductService.GetById(id);
		return View(product);
	}

	public ActionResult Create()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<ActionResult> Create(ProductRequestDto dto)
	{
		try
		{
			var file = Request.Form.Files["AvatarImage"];
			await _ProductService.Create(dto, file);

			return RedirectToAction(nameof(Index));
		}
		catch (Exception ex)
		{
			ViewData["Error"] = ex.Message;
			return View(dto);
		}
	}

	[HttpGet("Products/Edit/{id}")]
	public ActionResult EditAsync(Guid id)
	{
		try
		{
			var product = _ProductService.GetById(id);
			return View(product);
		}
		catch (ResourceNotFoundException ex)
		{
			return NotFound();
		}
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<ActionResult> Edit(Guid id, ProductRequestDto dto)
	{
		try
        {
            var file = Request.Form.Files["AvatarImage"];
            await _ProductService.Edit(id, dto, file);
			return RedirectToAction(nameof(Index));
		}
		catch (ResourceNotFoundException ex)
		{
			return NotFound();
		}
	}

	[HttpGet("Products/Delete/{id}")]
	public ActionResult DeleteAsync(Guid id)
	{
		try
		{
			var product = _ProductService.GetById(id);
			return View(product);
		}
		catch (ResourceNotFoundException ex)
		{
			return NotFound();
		}
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Delete(Guid id, ProductRequestDto dto)
	{
		try
		{
			_ProductService.DeleteById(id);
			return RedirectToAction(nameof(Index));
		}
		catch (ResourceNotFoundException ex)
		{
			return NotFound();
		}
		catch (InvalidOperationException ex)
		{
			return BadRequest(ex.Message);
		}
	}
}