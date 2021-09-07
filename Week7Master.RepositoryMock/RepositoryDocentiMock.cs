using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.Core.InterfaceRepositories;

namespace Week7Master.RepositoryMock
{
    public class RepositoryDocentiMock : IRepositoryDocenti
    {
        public static List<Docente> Docenti = new List<Docente>()
        {
            new Docente{ID=1, Nome="Mario", Cognome="Rossi", Email="mario@mail.it", Telefono="3331234567"},
            new Docente{ID=2, Nome="Giuseppe", Cognome="Bianchi", Email="giuseppe@mail.it", Telefono="3331434567"}
        };

        public Docente Add(Docente item)
        {
            if (Docenti.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                item.ID =Docenti.Max(s => s.ID) + 1;
            }

            Docenti.Add(item);
            return item;
        }

        public bool Delete(Docente item)
        {
            Docenti.Remove(item);
            return true;
        }

        public List<Docente> GetAll()
        {
            return Docenti;
        }

        public Docente GetById(int id)
        {
            return Docenti.FirstOrDefault(s => s.ID == id);
        }

        public Docente GetByName(string nome, string cognome, string email)
        {
            return Docenti.FirstOrDefault(d => d.Nome == nome && d.Cognome == cognome && d.Email == email);
        }

        public Docente Update(Docente item)
        {
            var old = GetByName(item.Nome, item.Cognome, item.Email);
            old.Telefono = item.Telefono;
            old.Email = item.Email;
            return item;
        }
    }
}
