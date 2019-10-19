namespace Bfh.Wba.AspNetCore.Web.Models
{
	public class KontoGruppe
	{
		public string Id { get; set; } = string.Empty;
		public int Level { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
		public string Beschreibung { get; set; } = string.Empty;
		public KontoGruppenListe Untergruppen { get; } = new KontoGruppenListe();
	}
}
