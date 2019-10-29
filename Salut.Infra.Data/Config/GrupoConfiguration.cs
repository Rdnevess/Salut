using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salut.Domain.Entities;

namespace Salut.Infra.Data.Config {
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo> {

        public void Configure(EntityTypeBuilder<Grupo> builder) {

            builder.HasKey(p => p.Id);
            builder.Property(g => g.Nome).IsRequired().HasMaxLength(100);
            builder.Property(g => g.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(g => g.UrlFoto).IsRequired().HasMaxLength(400);
            builder.HasMany(g => g.Postagens).WithOne(p => p.Grupo);


        }
    }
}
