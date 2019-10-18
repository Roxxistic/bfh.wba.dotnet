using System.Collections.Generic;
using Bfh.Wba.AspNetCore.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Bfh.Wba.AspNetCore.Web.RazorHelpers
{
	public class DepartmentOptionTagHelper: TagHelper
	{
		public Department Department { get; set; }
		public string PreselectedDepartmentId { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "option";
			output.Attributes.Add("value", Department.Id);
			output.Content.SetContent(Department.Name);
			if (Department.Id == PreselectedDepartmentId)
			{
				output.Attributes.Add("selected", "selected");
			}
		}
	}

	public class DepartmentSelectorTagHelper : TagHelper
	{
		public List<Department> Departments { get; set; }
		public string PreselectedDepartmentId { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			
			output.TagName = "select";
			foreach (var department in Departments)
			{
				var selected = department.Id == PreselectedDepartmentId ? "selected=\"selected\"" : string.Empty;
				output.Content.AppendHtml($"<option value=\"{department.Id}\" {selected}>{department.Name} ({department.Id})</option>");
			}
		}
	}
}
