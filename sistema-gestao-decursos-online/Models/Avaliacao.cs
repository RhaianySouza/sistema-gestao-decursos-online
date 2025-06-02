/**
 * Modelo: Avaliacao
 * Descrição: Representa a tabela de junção entre as entidades 'Usuario' e 'Curso', 
 * sem atributos adicionais além das chaves estrangeiras.
 * Data de criação: 29/04/2025
 * Autora: Rhaiany Cezar de Souza
 */
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema_gestao_decursos_online.Models
{
    public class AvaliacaoModel
    {
        [Key]
        public int AvaliacaoId { get; set; }

        [Required]
        public int MatriculaId { get; set; }

        [ForeignKey("MatriculaId")]
        public MatriculaModel Matricula { get; set; }

        [Required]
        [Range(1, 10)]
        public int Nota { get; set; }

        [StringLength(500)]
        public string? Comentario { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
