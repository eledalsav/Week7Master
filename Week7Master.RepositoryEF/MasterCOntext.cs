using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;

namespace Week7Master.RepositoryEF
{
    public class MasterCOntext:DbContext

    {
        public DbSet<Corso> corsi { get; set; }
        public DbSet<Studente> studenti { get; set; }
        public DbSet<Lezione> lezioni { get; set; }
        public DbSet<Docente> docenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)mssqllocaldb;Database=CorsiMaster; Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration<Corso>(new CorsoConfiguration());
            modelbuilder.ApplyConfiguration<Studente>(new StudenteConfiguration());
            modelbuilder.ApplyConfiguration<Docente>(new DocenteConfiguration());
            modelbuilder.ApplyConfiguration<Lezione>(new LezioneConfiguration());

        }
    }
}
