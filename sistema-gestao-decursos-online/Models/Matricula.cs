/**
 * Modelo: Matricula
 * Descrição: Define a tabela de junção entre 'usuarios' e 'cursos' com informações adicionais.
 * Data de Criação: 29/04/2025
 * Autora: Rhaiany Cezar de Souza
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema_gestao_decursos_online.Models
{
    public class MatriculaModel
    {
        [Key]
        public int MatriculaId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioModel Usuario { get; set; }

        [Required]
        public int CursoId { get; set; }

        [ForeignKey("CursoId")]
        public CursoModel Curso { get; set; }

        [Required]
        public DateTime DataMatricula { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public ICollection<AvaliacaoModel> Avaliacoes { get; set; }
    }
}
