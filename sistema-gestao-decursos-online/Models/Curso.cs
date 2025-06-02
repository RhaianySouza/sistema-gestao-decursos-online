/**
 * Modelo: Curso
 * Descrição: Define a estrutura da tabela 'curso' no banco de dados.
 * Data de Criação: 29/04/2025
 * Autora: Rhaiany Cezar de Souza
 */

using System.ComponentModel.DataAnnotations;

namespace sistema_gestao_decursos_online.Models
{
    public class CursoModel
    {
        [Key]
        public int CursoId { get; set; }

        [Required, StringLength(100)]
        public string Titulo { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        public int CargaHoraria { get; set; }

        // Relacionamentos
        public List<CursoUsuarioModel> CursosUsuarios { get; set; }
        public List<MatriculaModel> Matriculas { get; set; }
        public List<AvaliacaoModel> Avaliacoes { get; set; }
    }
}
