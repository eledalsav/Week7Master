using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Week7Master.Core.Entities;

namespace Week7Master.MVC.Models
{
    public class LezioneViewModel : Controller
    {
        [Required]
        public int LezioneID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataOraInizio { get; set; }
        [Required]
        public int Durata { get; set; }
        [Required]
        public string Aula { get; set; }

        //FK verso Docente
        public int DocenteID { get; set; }
        public DocentiViewModel Docente { get; set; }


        //Fk verso Corso
        public string CorsoCodice { get; set; }
        public CorsoViewModel Corso { get; set; }
    }
}
