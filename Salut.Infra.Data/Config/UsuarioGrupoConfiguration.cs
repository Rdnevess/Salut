using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salut.Domain.Entities;

namespace Salut.Infra.Data.Config {
    public class UsuarioGrupoConfiguration : IEntityTypeConfiguration<UsuarioGrupo> {

        public void Configure(EntityTypeBuilder<UsuarioGrupo> builder) {

            builder.HasKey(u => new { u.UsuarioId, u.GrupoId });
            builder.Property(u => u.DataCriacao).IsRequired();
            builder.Property(u => u.EhAdministrador);


        }
    }
}
