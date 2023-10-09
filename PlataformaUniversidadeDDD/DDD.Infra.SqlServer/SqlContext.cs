using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.TiContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Matricula>().HasKey(m => new { m.AlunoId, m.DisciplinaId });


            //Tentei Fazer aqui a relação das entidades Tecnico com Chamado e Chamador com Chamado

            modelBuilder.Entity<Tecnico>()
                .HasMany(c => c.Chamados)
                .WithOne(c => c.Tecnico)
                .HasForeignKey(e => e.IdTecnico)
                .IsRequired(false);

            modelBuilder.Entity<Chamador>()
                .HasMany(c => c.Chamados)
                .WithOne(c => c.Chamador)
                .HasForeignKey(e => e.IdChamador);
             

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Disciplinas)
                .WithMany(e => e.Alunos)
                .UsingEntity<Matricula>();


            


            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Pesquisador>().ToTable("Pesquisador");
            modelBuilder.Entity<Tecnico>().ToTable("Tecnico");
            modelBuilder.Entity<Chamador>().ToTable("Chamador");
            //https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pesquisador> Pesquisadores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Chamador> Chamadores { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
    }
}
