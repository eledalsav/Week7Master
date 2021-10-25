using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7Master.Core.Entities;

namespace Week7Master.RepositoryEF
{
    internal class CorsoConfiguration : IEntityTypeConfiguration<Corso>
    {
        public void Configure(EntityTypeBuilder<Corso> modelBuilder)
        {
           modelBuilder.ToTable("Corso");
            modelBuilder.HasKey(c => c.CorsoCodice);
        }
    }
}