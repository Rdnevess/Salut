﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salut.Domain.Entities;

namespace Salut.Infra.Data.Config {
    public class AmigoConfiguration : IEntityTypeConfiguration<Amigo> {

        public void Configure(EntityTypeBuilder<Amigo> builder) {

            builder.HasKey(a => new { a.UsuarioId, a.UsuarioAmigoId });


        }
    }
}
