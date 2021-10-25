using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7Master.Core.Entities;

namespace Week7Master.RepositoryEF
{
    internal class LezioneConfiguration : IEntityTypeConfiguration<Lezione>
    {
        public void Configure(EntityTypeBuilder<Lezione> builder)
        {
            builder.ToTable("Lezione");
            builder.HasKey(l => l.LezioneID);
        }
    }
}