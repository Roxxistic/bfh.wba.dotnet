using Bfh.Wba.AspNetCore.Web.FakeData;
using Bfh.Wba.AspNetCore.Web.Models;
using Bfh.Wba.AspNetCore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bfh.Wba.AspNetCore.Web.Controllers
{
	public class KontoController : Controller
	{
		public IActionResult Index(KontoGruppeTyp? typ)
		{
			if (typ == null)
			{
				var list = new KontoGruppenListe();
				return View();
			}
			var vm = new KontoIndexViewModel(KontoData.Funktionen, KontoData.SachgruppenBilanz, KontoData.SachgruppenER, KontoData.SachgruppenIR);
			return View(vm);
		}

		[Route("Konto/{type}/{id?}")]
		public IActionResult Detail(KontoGruppeTyp type, string? id, string? selectedId)
		{
			var vm = new KontoGruppeTreeItem(GetKontoGruppe(type, id), selectedId, GetKey(type));

			return View(vm);
		}

		private KontoGruppe GetKontoGruppe(KontoGruppeTyp type, string? id)
		{
			if (string.IsNullOrEmpty(id))
			{
				var kg = new KontoGruppe()
				{
					Name = GetName(type)
				};
				kg.Untergruppen.AddRange(KontoData.Funktionen);
				return kg;
			}
			else
			{
				return KontoData.Funktionen.Find(id);
			}
		}

		private string GetName(KontoGruppeTyp type)
		{
			switch (type)
			{
				case KontoGruppeTyp.Funktionen:
					return "Funktionen";
				case KontoGruppeTyp.SachgruppenBilanz:
					return "Sachgruppen Bilanz";
				case KontoGruppeTyp.SachgruppenEr:
					return "Sachgruppen ER";
				case KontoGruppeTyp.SachgruppenIr:
					return "Sachgruppen IR";
				default:
					return "Funktionen";
			}
		}

		private string GetKey(KontoGruppeTyp type)
		{
			switch (type)
			{
				case KontoGruppeTyp.Funktionen:
					return nameof(KontoGruppeTyp.Funktionen);
				case KontoGruppeTyp.SachgruppenBilanz:
					return nameof(KontoGruppeTyp.SachgruppenBilanz);
				case KontoGruppeTyp.SachgruppenEr:
					return nameof(KontoGruppeTyp.SachgruppenEr);
				case KontoGruppeTyp.SachgruppenIr:
					return nameof(KontoGruppeTyp.SachgruppenIr);
				default:
					return nameof(KontoGruppeTyp.Funktionen);
			}
		}
	}
}