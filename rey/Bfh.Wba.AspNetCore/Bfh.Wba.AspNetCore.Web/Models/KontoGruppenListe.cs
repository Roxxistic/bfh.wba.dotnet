using System.Collections.Generic;

namespace Bfh.Wba.AspNetCore.Web.Models
{
	public class KontoGruppenListe : List<KontoGruppe>
	{
		public KontoGruppe Find(string id)
		{
			foreach (var g in this)
			{
				if (g.Id == id)
					return g;
				else if (id.StartsWith(g.Id))
					return g.Untergruppen.Find(id);
			}

			return null;
		}
	}

	public class KontoGruppeTreeItem
	{
		public KontoGruppe KontoGruppe { get; }
		public bool IsSelected { get; }
		public string KontoGruppeTypKey { get; }

		public KontoGruppeTreeItem(KontoGruppe kontoGruppe, string selectedKontoGruppeId, string kontoGruppeTypKey)
		{
			KontoGruppe = kontoGruppe;
			IsSelected = !string.IsNullOrEmpty(selectedKontoGruppeId) && selectedKontoGruppeId == kontoGruppe.Id;
			KontoGruppeTypKey = kontoGruppeTypKey;
		}
	}
}