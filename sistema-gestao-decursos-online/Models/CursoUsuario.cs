/**
 * Modelo: CursoUsuario
 * Descrição: Define a tabela de junção entre 'usuarios' e 'cursos' sem informações adicionais.
 * Data de Criação: 29/04/2025
 * Autora: Rhaiany Cezar de Souza
 */

using System.ComponentModel.DataAnnotations;

namespace sistema_gestao_decursos_online.Models
{
    public class CursoUsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

        [Required]
        public int CursoId { get; set; }
        public CursoModel Curso { get; set; }
    }
}
