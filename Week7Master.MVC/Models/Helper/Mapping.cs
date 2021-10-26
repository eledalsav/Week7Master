using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7Master.Core.Entities;

namespace Week7Master.MVC.Models.Helper
{
    public static class Mapping
    {
        public static CorsoViewModel ToCorsoViewModel(this Corso corso)
        {

            return new CorsoViewModel
            {
                CorsoCodice = corso.CorsoCodice,
                Nome = corso.Nome,
                Descrizione = corso.Descrizione
            };
        }

        public static Corso ToCorso(this CorsoViewModel corsoViewModel)
        {

            return new Corso
            {
                CorsoCodice = corsoViewModel.CorsoCodice,
                Nome = corsoViewModel.Nome,
                Descrizione = corsoViewModel.Descrizione,
                //Studenti = null,
                //Lezioni = null
            };
        }

        public static DocentiViewModel ToDocentiViewModel(this Docente docente)
        {

            return new DocentiViewModel
            {
               ID=docente.ID,
               Nome=docente.Nome,
               Cognome=docente.Cognome,
               Telefono=docente.Telefono,
               Email=docente.Email

            };
        }

        public static Docente ToDocenti(this DocentiViewModel docentiViewModel)
        {

            return new Docente
            {
                Nome = docentiViewModel.Nome,
                Cognome=docentiViewModel.Cognome,
                ID=docentiViewModel.ID,
                Email=docentiViewModel.Email,
                Telefono=docentiViewModel.Telefono
        
            };
        }

        public static StudentiViewModel ToStudentiViewModel(this Studente studente)
        {

            return new StudentiViewModel
            {
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                ID = studente.ID,
                Email = studente.Email,
                DataNascita = studente.DataNascita,
                TitoloStudio = studente.TitoloStudio

            };
        }

        public static Studente ToStudente(this StudentiViewModel studentiViewModel)
        {

            return new Studente
            {
                Nome = studentiViewModel.Nome,
                Cognome = studentiViewModel.Cognome,
                ID = studentiViewModel.ID,
                Email = studentiViewModel.Email,
               DataNascita=studentiViewModel.DataNascita,
               TitoloStudio=studentiViewModel.TitoloStudio

            };
        }

    }
}
