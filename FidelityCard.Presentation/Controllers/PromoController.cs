using Microsoft.AspNetCore.Mvc;

namespace FidelityCard.Presentation.Controllers;

public class PromosController : Controller
{

	public ActionResult Promos()
	{
		return View();
	}

}
