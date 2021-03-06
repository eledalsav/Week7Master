using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7Master.Core.BusinessLayer;
using Week7Master.MVC.Models;
using Week7Master.MVC.Models.Helper;

namespace Week7Master.MVC.Controllers
{
    public class CorsiController : Controller
    {
        private readonly IBusinessLayer BL;

        public CorsiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        //CRUD su corso


        //url: https...../Corsi
        [HttpGet]
        public IActionResult Index()
        {
            var corsi = BL.GetAllCorsi();

            List<CorsoViewModel> corsiViewModel = new List<CorsoViewModel>();

            foreach (var item in corsi)
            {
                corsiViewModel.Add(item.ToCorsoViewModel());
            }

            return View(corsiViewModel);
        }


        //url: https...../Corsi/Details/C-01

        [HttpGet("Corsi/Details/{codice}")]
        //[HttpGet] // [HttpGet ("Corsi/Details/{id}")]
        public IActionResult Details(string codice)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CorsoCodice == codice);

            var corsoViewModel = corso.ToCorsoViewModel();

            return View(corsoViewModel);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.ToCorso();
                BL.InserisciNuovoCorso(corso);
                return RedirectToAction(nameof(Index));
            }
            return View(corsoViewModel);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CorsoCodice == id);
            var corsoViewModel = corso.ToCorsoViewModel();
            return View(corsoViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.ToCorso();
                BL.ModificaCorso(corso.CorsoCodice, corso.Nome, corso.Descrizione);
                return RedirectToAction(nameof(Index));
            }
            return View(corsoViewModel);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CorsoCodice == id);
            var corsoViewModel = corso.ToCorsoViewModel();
            return View(corsoViewModel);
        }

        [HttpPost]
        public IActionResult Delete(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {

                var corso = corsoViewModel.ToCorso();
                BL.EliminaCorso(corso.CorsoCodice);
                return RedirectToAction(nameof(Index));

            }
            return View(corsoViewModel);
        }
    }
}
