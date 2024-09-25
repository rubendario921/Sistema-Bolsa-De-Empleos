using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Educacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EduId { get; set; }
        [StringLength(250)]
        public required string EduTitulo { get; set; }
        [StringLength(100)]
        public required string EduPais { get; set; }
        [StringLength(100)]
        public required string EduTipoEstudio { get; set; }
        [StringLength(100)]
        public required string EduArea {  get; set; }
        [StringLength(250)]
        public required string EduInstitucion { get; set; }
        [StringLength(100)]
        public required string EduNivel { get; set; }
        public DateOnly EduFechaInicio { get; set; }
        public DateOnly EduFechaFin {  get; set; }
        public virtual ICollection<Candidatos> Candidato { get; set; } = [];
    }
}
