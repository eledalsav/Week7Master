using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Week7Master.Core.Entities;

namespace Week7Master.MVC.Models
{
    public class DocentiViewModel:PersonaViewModel
    {
        [Required]
        public string Telefono { get; set; }

        //public List<Lezione> Lezioni { get; set; } = new List<Lezione>();
        public List<LezioneViewModel> Lezioni { get; set; } = new List<LezioneViewModel>();
       
    }
}
