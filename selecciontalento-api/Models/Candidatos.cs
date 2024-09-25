using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Candidatos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CanId { get; set; }
        public required string CanNombre { get; set; }
        [StringLength(250)]
        public required string CanApellido { get; set; }
        [StringLength(100)]
        public required string CanNacionalidad { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        [StringLength(50)]
        public required string CanEstadoCivil { get; set; }
        [StringLength(2)]
        public required string CanTipoDni { get; set; }
        [StringLength(10)]
        public required string CanNumDni { get; set; }
        public required string CanPassword { get; set; }
        [StringLength(50)]
        public required string CanGenero { get; set; }
        //Datos Contacto
        public int DcId { get; set; }
        public virtual Educacion? Educacion { get; set; }
        //Experiencia
        public int ExpId { get; set; }
        public virtual Experiencias? Experiencia { get; set; }
        //Cursos
        public int CurId { get; set; }
        public virtual Cursos? Curso { get; set; }
        //Idioma
        public ICollection<CandidatoIdioma> CandidatoIdioma { get; set; }
        //public int IdiId { get; set; }
        //public virtual Idiomas? Idioma { get; set; }
    }
}
