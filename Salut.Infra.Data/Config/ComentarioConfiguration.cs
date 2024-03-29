﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salut.Domain.Entities;

namespace Salut.Infra.Data.Config {
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario> {

        public void Configure(EntityTypeBuilder<Comentario> builder) {

            builder.HasKey(c => c.Id);
            builder.Property(c => c.DataPublicacao).IsRequired();
            builder.Property(c => c.Texto).IsRequired().HasMaxLength(600);


        }
    }
}
