using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Domain
{
    [Table("TAB_Aluno")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(1)]
        [Column(TypeName = "char")]
        public string Sexo { get; set; }

        [Required]
        [ForeignKey("Curso")]
        public int CursoId { get; set; }

        public virtual Curso Curso { get; set; }
    }
}