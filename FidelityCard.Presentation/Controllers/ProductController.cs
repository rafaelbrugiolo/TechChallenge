﻿using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Interfaces;
using FidelityCard.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FidelityCard.Presentation.Controllers;

public class ProductsController : Controller
{
	private readonly IProductService _ProductService;
	private readonly ICompanyService _CompanyService;

	public ProductsController(IProductService ProductService, ICompanyService CompanyService)
	{
		_ProductService = ProductService;
		_CompanyService = CompanyService;
	}

	public ActionResult Index()
	{
		var products = _ProductService.GetAll().ToArray();
		return View(products);
	}

	public ActionResult Details(Guid id)
	{
		var product = _ProductService.GetById(id);
		return View(product);
	}

	public ActionResult Create()
	{
		var companies = _CompanyService.GetAll().ToArray();
		ViewBag.Companies = companies;

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
			var companies = _CompanyService.GetAll().ToArray();
			ViewBag.Companies = companies;
			return View(dto);
		}
	}

	[HttpGet("Products/Edit/{id}")]
	public ActionResult Edit(Guid id)
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
	public ActionResult Edit(Guid id, ProductRequestDto dto)
	{
		try
		{
			var file = Request.Form.Files["AvatarImage"];
			_ProductService.Edit(id, dto, file);
			return RedirectToAction(nameof(Index));
		}
		catch (ResourceNotFoundException ex)
		{
			return NotFound();
		}
	}

	[HttpGet("Products/Delete/{id}")]
	public ActionResult Delete(Guid id)
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
	}
}
