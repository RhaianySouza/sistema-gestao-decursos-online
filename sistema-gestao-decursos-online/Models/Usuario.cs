/**
 * Modelo: Usuario
 * Descrição: Define a estrutura da tabela 'usuarios' no banco de dados.
 * Data de Criação: 29/04/2025
 * Autora: Rhaiany Cezar de Souza
 */
using System.ComponentModel.DataAnnotations;

namespace sistema_gestao_decursos_online.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [Required, StringLength(150)]
        public string Email { get; set; }

        [Required, StringLength(100, MinimumLength = 6)]
        public string Senha { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        // Relacionamentos
        public List<CursoUsuarioModel> CursosUsuarios { get; set; }
        public List<MatriculaModel> Matriculas { get; set; }
        public List<AvaliacaoModel> Avaliacoes { get; set; }
    }
}

