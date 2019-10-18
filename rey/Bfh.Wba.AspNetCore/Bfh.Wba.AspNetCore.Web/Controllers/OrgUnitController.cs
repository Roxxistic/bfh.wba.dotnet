using Microsoft.AspNetCore.Mvc;

namespace Bfh.Wba.AspNetCore.Web.Controllers
{
	[Route("OrgUnit")]
	public class OrgUnitController : Controller
	{
		[Route("Details/{*hierarchy}")]
		public IActionResult Details(string hierarchy)
		{

			return !string.IsNullOrEmpty(hierarchy) ? Ok($"Detail for '{hierarchy}'") : Ok( "no detail");
		}

		[Route("Edit/{*hierarchy}")]
		public IActionResult Edit(string hierarchy)
		{
			return !string.IsNullOrEmpty(hierarchy) ? Ok($"Edit for '{hierarchy}'") : Ok( "no edit");
		}

	}
}