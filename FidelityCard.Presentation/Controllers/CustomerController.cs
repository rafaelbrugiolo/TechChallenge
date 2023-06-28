using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;
using FidelityCard.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FidelityCard.Presentation.Controllers;

public class CustomerController : Controller
{
	private readonly ICustomerService _CustomerService;

	public CustomerController(ICustomerService CustomerService)
	{
		_CustomerService = CustomerService;
	}

	public ActionResult Index()
	{
		var products = _CustomerService.GetAll().ToArray();
		return View(products);
	}

	public ActionResult DetailsAsync(Guid id)
	{
		var customer = _CustomerService.GetById(id);
		return View(customer);
	}

	public ActionResult Create()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create(CustomerRequestDto dto)
	{
		try
		{
			_CustomerService.Create(dto);

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
			var customer = _CustomerService.GetById(id);
			return View(customer);
		}
		catch (ResourceNotFoundException ex)
		{
			return NotFound();
		}
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(Guid id, CustomerRequestDto dto)
	{
		try
		{
			_CustomerService.Edit(id, dto);
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
			var customer = _CustomerService.GetById(id);
			return View(customer);
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
			_CustomerService.DeleteById(id);
			return RedirectToAction(nameof(Index));
		}
		catch (ResourceNotFoundException ex)
		{
			return NotFound();
		}
	}
}
