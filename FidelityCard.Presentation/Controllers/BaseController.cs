using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace FidelityCard.Presentation.Controllers;

public class BaseController : Controller
{
	public BaseController()
	{
		var cultureInfo = CultureInfo.GetCultureInfo("en-us");
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
	}
}
