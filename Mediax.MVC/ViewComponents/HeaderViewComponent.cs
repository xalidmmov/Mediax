using Microsoft.AspNetCore.Mvc;

namespace Mediax.MVC.ViewComponents
{
	public class HeaderViewComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
