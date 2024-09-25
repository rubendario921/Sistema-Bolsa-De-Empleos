using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Experiencias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpId { get; set; }
        [StringLength(100)]
        public required string ExpEmpresa { get; set; }
        public required string ExpActividad { get; set; }
        public required string ExpPuesto { get; set; }
        public required string ExpNivelExperiencia { get; set; }
        public required string ExpArea { get; set; }
        public required string ExpSubArea { get; set; }
        public required string ExpPais { get; set; }
        public DateOnly ExpFechaInicio { get; set; }
        public DateOnly ExpFechaFin { get; set; }
        public required string ExpDetalle { get; set; }
        public required string ExpPersonasCargo { get; set; }
        public virtual ICollection<Candidatos> Candidato { get; set; } = [];
    }
}