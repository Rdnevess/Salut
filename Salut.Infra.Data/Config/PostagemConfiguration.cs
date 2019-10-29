using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salut.Domain.Entities;

namespace Salut.Infra.Data.Config {
    public class PostagemConfiguration : IEntityTypeConfiguration<Postagem> {
        public void Configure(EntityTypeBuilder<Postagem> builder) {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.DataPublicacao).IsRequired();
            builder.Property(p => p.Text).IsRequired().HasMaxLength(400);
            builder.HasOne(p => p.Usuario).WithMany(u => u.Postagens);

        }
    }
}
