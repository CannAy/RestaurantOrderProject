using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarComponentPartial :ViewComponent
	{
		IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
