/**
 * Classe: GestaoCursoOnlineDbInitializer
 * Descrição: Responsável pela inicialização e popularização do banco de dados com dados iniciais para o sistema de gestão de cursos online.
 * Data de Criação: 29/04/2025
 */
using sistema_gestao_decursos_online.Models;

namespace sistema_gestao_decursos_online.Database
{
    public class GestaoCursoOnlineDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Verifica se já existem usuários no banco
            if (context.Usuarios.Any())
            {
                return; // Banco foi inicializado
            }

            // Dados iniciais de usuários
            var usuarios = new UsuarioModel[]
            {
                new UsuarioModel {Nome = "João Silva", Email = "joao@email.com", Senha = "senha123", Telefone ="2499999-9999" },
                new UsuarioModel {Nome = "Maria Souza", Email = "maria@email.com", Senha = "senha456",Telefone ="2499999-9999" }
            };

            foreach (var u in usuarios)
            {
                context.Usuarios.Add(u);
            }
            context.SaveChanges();

            // Dados iniciais de cursos
            var cursos = new CursoModel[]
            {
                new CursoModel {Titulo = "Curso de C#", Descricao = "Aprenda C# do básico ao avançado.",CargaHoraria=36},
                new CursoModel {Titulo = "Curso de Redes", Descricao = "Fundamentos de redes de computadores.", CargaHoraria=12},
                new CursoModel {Titulo = "Curso de Java", Descricao = "Aprenda Java do básico ao avançado.", CargaHoraria=40},
                new CursoModel {Titulo = "Curso de Informatica Basica", Descricao = "Fundamentos de Informatica Basica.",CargaHoraria=12 }
            };

            foreach (var c in cursos)
            {
                context.Cursos.Add(c);
            }
            context.SaveChanges();

            // Dados iniciais de relacionamento curso-usuário (muitos para muitos)
            var cursosUsuarios = new CursoUsuarioModel[]
            {
                new CursoUsuarioModel {CursoId = cursos[0].CursoId, UsuarioId = usuarios[0].UsuarioId },
                new CursoUsuarioModel {CursoId = cursos[1].CursoId, UsuarioId = usuarios[0].UsuarioId }
            };

            foreach (var cu in cursosUsuarios)
            {
                context.CursosUsuarios.Add(cu);
            }
            context.SaveChanges();

            // Dados iniciais de matrículas
            var matriculas = new MatriculaModel[]
            {
                new MatriculaModel {CursoId = 1, UsuarioId = 1, DataMatricula = DateTime.Now },
                new MatriculaModel {CursoId = 2, UsuarioId = 2, DataMatricula = DateTime.Now }
            };

            foreach (var m in matriculas)
            {
                context.Matriculas.Add(m);
            }
            context.SaveChanges();
        }
    }
}