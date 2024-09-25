using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Modalidades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModId { get; set; }        
        public required string ModName { get; set; }
        public string? ModInformacion {  get; set; }
        //Relacion con Tabla Ofertas Empleo
        public int OfEmpId { get; set; }
        public virtual ICollection<OfertaEmpleos> OfertaEmpleados { get; set; } = [];
    }
}
