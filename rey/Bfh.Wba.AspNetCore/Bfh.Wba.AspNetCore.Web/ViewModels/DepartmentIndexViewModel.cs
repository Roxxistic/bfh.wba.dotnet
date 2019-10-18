using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bfh.Wba.AspNetCore.Web.Models;

namespace Bfh.Wba.AspNetCore.Web.ViewModels
{
	public class DepartmentIndexViewModel
	{
		public List<Department> Departments { get; set; }
		public string PreselectedDepartmentId { get; set; }
	}
}
