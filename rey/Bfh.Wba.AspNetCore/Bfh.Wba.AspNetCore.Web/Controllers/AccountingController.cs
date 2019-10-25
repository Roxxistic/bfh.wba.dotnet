using System;
using System.Collections.Generic;
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

		[Route("{controller}/{action}/{topicType}")]
		public IActionResult Selection(AccountGroupCategory topicType, string functionId, string topicId)
		{
			string typeKey;
			string title;
			KontoGruppenListe topicGroupList;
			Dictionary<string, Konto> accounts;
			Konto account;
			switch (topicType)
			{
				case AccountGroupCategory.SachgruppenEr:
					typeKey = "ER";
					title = "Erfolgsrechnung";
					topicGroupList = FakeAccountingData.SachgruppenER;
					accounts = FakeAccountingData.ER;
					break;
				case AccountGroupCategory.SachgruppenIr:
					typeKey = "IR";
					title = "Investitionsrechnung";
					topicGroupList = FakeAccountingData.SachgruppenIR;
					accounts = FakeAccountingData.IR;
					break;
				default:
					typeKey = "";
					title = "";
					topicGroupList = new KontoGruppenListe();
					accounts = new Dictionary<string, Konto>();
					break;
			}

			ViewData["Type"] = typeKey;

			return View("ER_IR", new ER_IR_ViewModel
			{
				Title = title,
				Funktionen = FakeAccountingData.Funktionen,
				Sachgruppen = topicGroupList,
				Konten = accounts,
				Konto = new Konto
				{
					Funktion = FakeAccountingData.Funktionen.Find(functionId), 
					Sachgruppe = topicGroupList.Find(topicId)
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