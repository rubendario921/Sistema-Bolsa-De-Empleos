using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class DatosContacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DcId { get; set; }
        [StringLength(10)]
        public required string DcNumContacto { get; set; }
        [StringLength(10)]
        public required string DcNumContactoAlt { get; set; }
        [StringLength(50)]
        public required string DcPais {  get; set; }
        public required string DcProvincia {  get; set; }
        public required string DcCanton { get; set; }
        public required string DcDirrecion { get; set; }
        public required string DcEmail { get; set; }
        //Candidatos
        public virtual ICollection<Candidatos> Candidato { get; set; } = [];
    }
}
