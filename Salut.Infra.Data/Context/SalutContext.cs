using Microsoft.EntityFrameworkCore;
using Salut.Domain.Entities;
using Salut.Infra.Data.Config;

namespace Salut.Infra.Data.Context {
    public class SalutContext : DbContext{
        public DbSet<Usuario> Usuarios { get; set; }
        public SalutContext(DbContextOptions options) : base(options){

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
