﻿using Bfh.Wba.AspNetCore.Web.Models;
using ModelsExamples.Models;

namespace Bfh.Wba.AspNetCore.Web.ViewModels
{
	public class KontoIndexViewModel
	{
		public KontoGruppenListe Funktionen { get; }
		public KontoGruppenListe SachgruppenBilanz { get; }
		public KontoGruppenListe SachgruppenER { get; }
		public KontoGruppenListe SachgruppenIR { get; }

		public KontoIndexViewModel(KontoGruppenListe funktionen, KontoGruppenListe sachgruppenBilanz,
			KontoGruppenListe sachgruppenEr, KontoGruppenListe sachgruppenIr)
		{
			Funktionen = funktionen;
			SachgruppenBilanz = sachgruppenBilanz;
			SachgruppenER = sachgruppenEr;
			SachgruppenIR = sachgruppenIr;
		}
	}

	public enum KontoGruppeTyp
	{
		Funktionen,
		SachgruppenBilanz,
		SachgruppenEr,
		SachgruppenIr
	}
}
