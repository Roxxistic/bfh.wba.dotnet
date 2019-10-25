using System;
using Bfh.Wba.AspNetCore.Web.FakeData;
using Bfh.Wba.AspNetCore.Web.Models;
using Bfh.Wba.AspNetCore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Bfh.Wba.AspNetCore.Web.Controllers
{
	public class AccountingController : Controller
    {
	    public IActionResult Index()
        {
            return View();
        }

		[Route("{controller}/{action}/{type}")]
		public IActionResult Group(AccountGroupCategory type, string selectedGroupId)
		{
			return type switch
			{
				AccountGroupCategory.SachgruppenBilanz => Tree("Sachgruppen Bilanz", FakeAccountingData.SachgruppenBilanz, selectedGroupId),
				AccountGroupCategory.SachgruppenEr => Tree("Sachgruppen Erfolgsrechnung", FakeAccountingData.SachgruppenER, selectedGroupId),
				AccountGroupCategory.SachgruppenIr => Tree("Sachgruppen Investitionsrechnung", FakeAccountingData.SachgruppenIR, selectedGroupId),
				AccountGroupCategory.Funktionen => Tree("Funktionen", FakeAccountingData.Funktionen, selectedGroupId),
				_ => RedirectToAction("Index")
			};
		}

		public IActionResult ER(string funktion, string sachgruppe)
        {
            ViewData["Type"] = "ER";

            return View("ER_IR", new ER_IR_ViewModel
            {
                Title = "Erfolgsrechnung",
                Funktionen = FakeAccountingData.Funktionen,
                Sachgruppen = FakeAccountingData.SachgruppenER,
                Konten = FakeAccountingData.ER,
                Konto = new Konto
                {
                    Funktion = FakeAccountingData.Funktionen.Find(funktion), 
                    Sachgruppe = FakeAccountingData.SachgruppenER.Find(sachgruppe)
                }
            });
        }

        public IActionResult IR(string funktion, string sachgruppe)
        {
            ViewData["Type"] = "IR";

            return View("ER_IR", new ER_IR_ViewModel
            {
                Title = "Investitionsrechnung",
                Funktionen = FakeAccountingData.Funktionen,
                Sachgruppen = FakeAccountingData.SachgruppenIR,
                Konten = FakeAccountingData.IR,
                Konto = new Konto
                {
                    Funktion = FakeAccountingData.Funktionen.Find(funktion),
                    Sachgruppe = FakeAccountingData.SachgruppenIR.Find(sachgruppe)
                }
            });
        }

        public IActionResult Create(string funktion, string sachgruppe, string type)
        {
            ViewData["Type"] = type;

            return View(new Konto 
            {
                Nummer = 0,
                Name = "",
                Funktion = FakeAccountingData.Funktionen.Find(funktion),
                Sachgruppe = ((type == "ER") ? FakeAccountingData.SachgruppenER : FakeAccountingData.SachgruppenIR).Find(sachgruppe)
            });
        }

        [HttpPost]
        public IActionResult Create(Konto konto, string funktion, string sachgruppe, string type)
        {
            ViewData["Type"] = type;

            konto.Funktion = FakeAccountingData.Funktionen.Find(funktion);
            konto.Sachgruppe = ((type == "ER") ? FakeAccountingData.SachgruppenER : FakeAccountingData.SachgruppenIR).Find(sachgruppe);

            if (ModelState.IsValid)
            {
                try
                {
                    var list = ((type == "ER") ? FakeAccountingData.ER : FakeAccountingData.IR);
                    list.Add(konto.Kontonummer, konto);

                    return RedirectToAction(type);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }

            return View(konto);
        }

        protected IActionResult Tree(string title, KontoGruppenListe list, string id)
        {
            ViewData["Id"] = id;
            ViewData["Title"] = title;
            return View("Tree", list);
        }
    }
}