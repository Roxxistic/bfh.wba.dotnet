using System.Collections.Generic;

namespace Bfh.Wba.AspNetCore.Web.Models
{
    public class KontoGruppe
    {
        public string Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public KontoGruppenListe Untergruppen { get; } = new KontoGruppenListe();
    }

    public class KontoGruppenListe : List<KontoGruppe>
    {
        public KontoGruppe Find(string id)
        {
            if (id == null)
                return null;

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
}
