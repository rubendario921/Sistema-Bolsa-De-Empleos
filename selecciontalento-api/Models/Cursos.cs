using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Cursos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurId { get; set; }
        [StringLength(100)]
        public required string CurName { get; set; }
        public int CurHoras { get; set; }
        [StringLength(250)]
        public required string CurEmpresa { get; set; }
        [StringLength(10)]
        public required string CurCertificado { get; set; }
        public virtual ICollection<Candidatos> Candidato { get; set; } = [];
    }
}
