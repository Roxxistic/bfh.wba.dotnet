using Bfh.Wba.AspNetCore.Web.FakeData;
using Bfh.Wba.AspNetCore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bfh.Wba.AspNetCore.Web.Controllers
{
	public class DepartmentController : Controller
	{
		public IActionResult Index()
		{
			var data = DepartmentData.Departments;
			var vm = new DepartmentIndexViewModel()
			{
				Departments = DepartmentData.Departments,
				PreselectedDepartmentId = DepartmentData.Departments[2].Id
			};
			return View(vm);
		}
	}
}