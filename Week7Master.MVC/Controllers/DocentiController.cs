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
    }

}
