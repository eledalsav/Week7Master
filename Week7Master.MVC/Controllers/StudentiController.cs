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
    public class StudentiController : Controller
    {
        private readonly IBusinessLayer BL;

        public StudentiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var studenti = BL.GetAllStudenti();

            List<StudentiViewModel> studentiViewModel = new List<StudentiViewModel>();

            foreach (var item in studenti)
            {
                studentiViewModel.Add(item.ToStudentiViewModel());
            }


            return View(studentiViewModel);
        }




        [HttpGet("Docenti/Details/{codice}")]

        public IActionResult Details(int id)
        {

            Studente studente = BL.GetAllStudenti().FirstOrDefault(d => d.ID == id);

            var studentiViewModel = studente.ToStudentiViewModel();

            return View(studentiViewModel);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentiViewModel studentiViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studentiViewModel.ToStudente();
                BL.InserisciNuovoStudente(studente);
                return RedirectToAction(nameof(Index));
            }
            return View(studentiViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(s => s.ID == id);
            var studentiViewModel = studente.ToStudentiViewModel();
            return View(studentiViewModel);
        }

        [HttpPost]
        public IActionResult Edit(StudentiViewModel studentiViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studentiViewModel.ToStudente();
                BL.ModificaStudente(studente.ID, studente.Email);
                return RedirectToAction(nameof(Index));
            }
            return View(studentiViewModel);
        }

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
            
        //    BL.EliminaStudente(id);
        //    var studentiViewModel = studente.ToStudentiViewModel();
        //    return View(corsoViewModel);
        //}

        [HttpPost]
        public IActionResult Delete(StudentiViewModel studentiViewModel)
        {
            if (ModelState.IsValid)
            {

                var studente = studentiViewModel.ToStudente();
                BL.EliminaStudente(studente.ID);
                return RedirectToAction(nameof(Index));

            }
            return View(studentiViewModel);
        }
    }
}
