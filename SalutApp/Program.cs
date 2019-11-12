using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Salut.Domain.Entities;
using Salut.Infra.CrossCutting.Logging;
using Salut.Infra.Data.Context;
using System;
using System.Linq;

namespace SalutApp {
    class Program {
        static void Main(string[] args) {
            
            var optionsBuilder = new DbContextOptionsBuilder<SalutContext>();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql("Server=localhost;userid=root; password=admin; database=SalutDB;", m => m.MigrationsAssembly("Salut.Infra.Data"));
            optionsBuilder.EnableSensitiveDataLogging();

            try {
                using (var dbcontext = new SalutContext(optionsBuilder.Options)) {

                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    var usuarioNovo = CriarUsuario("Fernando");

                    dbcontext.Usuarios.Add(usuarioNovo);
                    dbcontext.SaveChanges();

                    var usuarioRetorno = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "Fernando");

                    if (usuarioRetorno == null) {
                        Console.WriteLine("Usuario não encontrado!");
                    }
                    else { 
                        Console.WriteLine("Nome do Usuario Criado => " + usuarioRetorno.Nome);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
                Console.ReadKey();
            }
            Console.WriteLine("OK");
            Console.ReadKey();
        }

        private static void AulaExibirChangeTracker(SalutContext dbcontext) {
            var usuario0 = CriarUsuario("usuario0");
            Console.WriteLine("Criando usuario0..");
            Console.WriteLine("Verificando o ChangeTracker de usuario0");
            dbcontext.Usuarios.Add(usuario0);
            ExibirChangeTracker(dbcontext.ChangeTracker);

            // #region Operations

            ////Obtendo
            var usuario1 = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "usuarioNovo1");
            Console.WriteLine("Obtendo usuario1");
            Console.WriteLine("Verificando o ChangeTracker de usuario1");
            ExibirChangeTracker(dbcontext.ChangeTracker);

            ////Editando
            Console.WriteLine("Editando usuario1");
            usuario1.Nome = "NovoNomeUsuario";
            Console.WriteLine("Verificando o ChangeTracker de usuario1");
            ExibirChangeTracker(dbcontext.ChangeTracker);

            ////Adicionando Novo
            var usuarioNovo2 = CriarUsuario("usuarioNovo2");
            Console.WriteLine("Adicionando usuarioNovo2");
            dbcontext.Usuarios.Add(usuarioNovo2);
            Console.WriteLine("Verificando o ChangeTracker de usuarioNovo2");
            ExibirChangeTracker(dbcontext.ChangeTracker);

            ////Deletando
            Console.WriteLine("Deletando usuario1");
            Console.WriteLine("Verificando o ChangeTracker de usuario1");
            dbcontext.Usuarios.Remove(usuario1);
            ExibirChangeTracker(dbcontext.ChangeTracker);

            ////Detached/desanexado
            var usuario3 = CriarUsuario("Usuario3");
            Console.WriteLine("Status do Usuario3");
            Console.WriteLine(dbcontext.Entry(usuario3).State);
            //#endregion
        }


        public static Usuario CriarUsuario(String nome) {
            return new Usuario() {
                Nome = nome,
                Sobrenome = "Sobreteste",
                Email = "teste@teste.com",
                Senha = "Buga",
                DataNascimento = DateTime.Now,
                Sexo = Salut.Domain.Enums.SexoEnum.Masculino,
                UrlFoto = @"C:\temp"
            };
        }

        private static void EnviarMensagemAmigos(Usuario usuario) {
            
        }

        private static void AtualizarDadosContato(Usuario usuario) {
            
        }

        public static void ExibirChangeTracker(ChangeTracker changeTracker) {
            foreach (var entry in changeTracker.Entries()) {
                Console.WriteLine("Nome da Instancia: " + entry.Entity.GetType().FullName);
                Console.WriteLine("Status da Entidade: " + entry.State);
                Console.WriteLine("-------------");
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
