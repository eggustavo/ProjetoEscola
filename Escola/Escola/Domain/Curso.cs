using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Domain
{
    [Table("TAB_Curso")]
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Duracao { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "varchar")]
        public string Periodo { get; set; }

        public virtual List<Aluno> AlunosMatriculadosNoCurso { get; set; }
    }
}