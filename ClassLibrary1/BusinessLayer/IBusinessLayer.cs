using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;

namespace Week7Master.Core.BusinessLayer
{
   public interface IBusinessLayer
    {
        #region Funzionalità Corsi
        //Visualizza corsi
        public List<Corso> GetAllCorsi();

        //Inserire un nuovo corso
        public string InserisciNuovoCorso(Corso newCorso);

        //Modifica Corso
        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione);
        //Elimina corso
        public string EliminaCorso(string codiceCorsoDaEliminare);

        #endregion

        #region Funzionalità Studenti
        //Visualizza tutti gli studenti
        public List<Studente> GetAllStudenti();

        public string InserisciNuovoStudente(Studente nuovoStudente);
        public string ModificaStudente(int idStudenteDaModificare, string nuovaEmail);
        public string EliminaStudente(int idStudenteDaEliminare);
        public List<Studente> GetStudentiByCorsoCodice(string codiceCorso);

        #endregion
        


        //#region Funzionalità Lezioni
        ////Visualizza corsi
        //public List<Corso> GetAllLezioni();

        ////Inserire un nuovo corso
        //public string InserisciNuovaLezione(Lezione newlezione);

        ////Modifica Corso
        //public string ModificaLezione(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione);
        ////Elimina corso
        //public string EliminaDocente(string codiceCorsoDaEliminare);

        //#endregion

        #region Funzionalità Docenti
        //Visualizza docenti
        public List<Docente> GetAllDocenti();

        //Inserire un nuovo corso
        public string InserisciNuovoDocente(Docente newDocente);

        //Modifica Corso
        public string ModificaDocente(string nomeDocente, string cognomeDocente, string emailDocente, string nuovoTelefono, string nuovaEmail);
        //Elimina corso
        public string EliminaDocente(int idDocenteDaEliminare);

        #endregion

    }
}
