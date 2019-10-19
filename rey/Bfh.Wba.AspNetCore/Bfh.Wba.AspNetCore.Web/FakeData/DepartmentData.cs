using System.Collections.Generic;
using Bfh.Wba.AspNetCore.Web.Models;

namespace Bfh.Wba.AspNetCore.Web.FakeData
{
	public class DepartmentData
	{
		public static List<Department> Departments
		{
			get
			{
				return new List<Department>
				{
					new Department {Id = "AHB", Name="Architektur, Holz und Bau" },
					new Department {Id = "HAFL", Name="Hochschule für Agrar-, Forst- und Lebensmittelwissenschaften" },
					new Department {Id = "HKB", Name="Hochschule der Künste Bern" },
					new Department {Id = "TI", Name="Technik und Informatik" },
					new Department {Id = "W", Name="Wirtschaft" },
					new Department {Id = "G", Name="Gesundheit" },
					new Department {Id = "S", Name="Soziale Arbeit" },
					new Department {Id = "EHSM", Name="Eidg. Hoschule für Sport Magglingen" }
				};
			}
		}
	}

    
}
