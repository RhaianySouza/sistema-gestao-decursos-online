/**
 * Classe: ApplicationDbContext
 * Descrição: Representa o contexto do banco de dados, gerenciando as entidades e suas configurações para o Entity Framework Core.
 * Data de Criação: 29/04/2025
 */
using Microsoft.EntityFrameworkCore;
using sistema_gestao_decursos_online.Models;

namespace sistema_gestao_decursos_online.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<CursoUsuarioModel> CursosUsuarios { get; set; }
        public DbSet<MatriculaModel> Matriculas { get; set; }
        public DbSet<AvaliacaoModel> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeiar as tabelas 
            modelBuilder.Entity<UsuarioModel>().ToTable("Usuarios");
            modelBuilder.Entity<CursoModel>().ToTable("Cursos");
            modelBuilder.Entity<CursoUsuarioModel>().ToTable("CursosUsuarios");
            modelBuilder.Entity<MatriculaModel>().ToTable("Matriculas");
            modelBuilder.Entity<AvaliacaoModel>().ToTable("Avaliacoes");

            // Chaves primárias
            modelBuilder.Entity<UsuarioModel>().HasKey(u => u.UsuarioId);
            modelBuilder.Entity<CursoModel>().HasKey(c => c.CursoId);
            modelBuilder.Entity<CursoUsuarioModel>().HasKey(cu => cu.Id);
            modelBuilder.Entity<MatriculaModel>().HasKey(m => m.MatriculaId);
            modelBuilder.Entity<AvaliacaoModel>().HasKey(a => a.AvaliacaoId);

            // Relacionamentos

            // CursoUsuario: Tabela de relacionamento N:N entre Cursos e Usuários
            // Relação N:N entre Curso e Usuario (favoritos, curtidos etc.)
            modelBuilder.Entity<CursoUsuarioModel>()
                .HasKey(cu => new { cu.CursoId, cu.UsuarioId });

            modelBuilder.Entity<CursoUsuarioModel>()
                .HasOne(cu => cu.Curso)
                .WithMany(c => c.CursosUsuarios)
                .HasForeignKey(cu => cu.CursoId);

            modelBuilder.Entity<CursoUsuarioModel>()
                .HasOne(cu => cu.Usuario)
                .WithMany(u => u.CursosUsuarios)
                .HasForeignKey(cu => cu.UsuarioId);

            // Matricula: 1 Usuario -> muitas Matriculas / 1 Curso -> muitas Matriculas
            modelBuilder.Entity<MatriculaModel>()
                .HasOne(m => m.Usuario)
                .WithMany(u => u.Matriculas)
                .HasForeignKey(m => m.UsuarioId);

            modelBuilder.Entity<MatriculaModel>()
                .HasOne(m => m.Curso)
                .WithMany(c => c.Matriculas)
                .HasForeignKey(m => m.CursoId);

            // Avaliação relacionada a Matrícula (1:N)
            modelBuilder.Entity<MatriculaModel>()
                .HasMany(m => m.Avaliacoes)
                .WithOne(a => a.Matricula)
                .HasForeignKey(a => a.MatriculaId);
        }
    }
}
