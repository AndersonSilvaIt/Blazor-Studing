using DigitalCursos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalCursos.Api.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Curso>()
                .HasKey(c => c.CursoId);

            mb.Entity<Curso>()
                .Property(b => b.CursoNome).HasMaxLength(150);

            mb.Entity<Curso>()
                .Property(b => b.Descricao).HasMaxLength(250);

            mb.Entity<Curso>()
                .Property(b => b.Preco)
                .HasColumnType("decimal(18,2)");

            mb.Entity<Aluno>()
                .Property(b => b.Nome).HasMaxLength(150);

            mb.Entity<Aluno>()
                .Property(b => b.Sobrenome).HasMaxLength(100);

            mb.Entity<Aluno>()
                .Property(b => b.Email).HasMaxLength(100);

            //dados

            mb.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = 1,
                    CursoNome = "CSharp Básico",
                    Descricao = "Curso de C# Básico",
                    CargaHoraria = 40,
                    Inicio = new DateTime(2025, 01, 09),
                    Preco = 150.00M,
                    Logo = null
                });

            mb.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = 2,
                    CursoNome = "ASP .NET Core Básico",
                    Descricao = "Curso de ASP .NET Core Básico",
                    CargaHoraria = 40,
                    Inicio = new DateTime(2025, 01, 15),
                    Preco = 250.00M,
                    Logo = null
                });

            mb.Entity<Aluno>().HasData(
                new Aluno
                {
                    AlunoId = 1,
                    Nome = "Felipe",
                    Sobrenome = "Ribeiro",
                    Email = "felipe@email.com",
                    Nascimento = new DateTime(2000, 10, 10),
                    Foto = null,
                    Genero = Genero.Masculino,
                    CursoId = 1
                });

            mb.Entity<Aluno>().HasData(
                new Aluno
                {
                    AlunoId = 2,
                    Nome = "Maria",
                    Sobrenome = "Silveira",
                    Email = "maria@email.com",
                    Nascimento = new DateTime(1995, 10, 10),
                    Foto = null,
                    Genero = Genero.Feminino,
                    CursoId = 2
                });
        }
    }
}