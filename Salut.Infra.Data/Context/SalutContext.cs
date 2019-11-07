using Microsoft.EntityFrameworkCore;
using Salut.Domain.Entities;
using Salut.Infra.Data.Config;

namespace Salut.Infra.Data.Context {
    public class SalutContext : DbContext{
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postagens { get; set;}
        public DbSet<StatusRelacionamento> StatusRelacionamento { get; set; }
        public DbSet<Grupo> Grupos{ get; set; }
        public DbSet<Identificacao> Identificacao { get; set; }
        public DbSet<UsuarioGrupo> UsuarioGrupos { get; set; }
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<InstituicaoEnsino> InstituicoesEnsino { get; set; }
        public DbSet<LocalTrabalho> LocaisTrabalho { get; set; }
        public DbSet<ProcurandoPor> ProcurandoPor { get; set; }



        public SalutContext(DbContextOptions options) : base(options){

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PostagemConfiguration());
            modelBuilder.ApplyConfiguration(new GrupoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioGrupoConfiguration());
            //modelBuilder.ApplyConfiguration(new UsuarioAmigoConfiguration());

            modelBuilder.ApplyConfiguration(new AmigoConfiguration());
            modelBuilder.ApplyConfiguration(new ComentarioConfiguration());
            modelBuilder.ApplyConfiguration(new StatusRelacionamentoConfiguration());
            modelBuilder.ApplyConfiguration(new ProcurandoPorConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
