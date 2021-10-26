using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7Master.Core.BusinessLayer;
using Week7Master.Core.Entities;
using Week7Master.MVC.Models;
using Week7Master.MVC.Models.Helper;

namespace Week7Master.MVC.Controllers
{
    public class DocentiController : Controller
    {
        private readonly IBusinessLayer BL;

        public DocentiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var docenti = BL.GetAllDocenti();

            List<DocentiViewModel> docentiViewModel = new List<DocentiViewModel>();

            foreach (var item in docenti)
            {
                docentiViewModel.Add(item.ToDocentiViewModel());
            }


            return View(docentiViewModel);
        }




        [HttpGet("Docenti/Details/{codice}")]
        
        public IActionResult Details(int id)
        {

            Docente docente = BL.GetAllDocenti().FirstOrDefault(d => d.ID==id);

            var docentiViewModel = docente.ToDocentiViewModel();

            return View(docentiViewModel);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DocentiViewModel docentiViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docentiViewModel.ToDocenti();
                BL.InserisciNuovoDocente(docente);
                return RedirectToAction(nameof(Index));
            }
            return View(docentiViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var docente = BL.GetAllDocenti().FirstOrDefault(d => d.ID == id);
            var docentiViewModel = docente.ToDocentiViewModel();
            return View(docentiViewModel);
        }

        //[HttpPost]
        //public IActionResult Edit(DocentiViewModel docentiViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var docente = docentiViewModel.ToDocenti();
        //        BL.ModificaDocente(docente.Nome, docente.Cognome, docente.Email, docente.Telefono, nuovaEmail);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(docentiViewModel);
        //}

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var docente= BL.GetAllDocenti().FirstOrDefault(d =>d.ID == id);
            var docenteViewModel = docente.ToDocentiViewModel();
            return View(docenteViewModel);
        }

        [HttpPost]
        public IActionResult Delete(DocentiViewModel docentiViewModel)
        {
            if (ModelState.IsValid)
            {

                var docente = docentiViewModel.ToDocenti();
                BL.EliminaDocente(docente.ID);
                return RedirectToAction(nameof(Index));

            }
            return View(docentiViewModel);
        }
    }

}
