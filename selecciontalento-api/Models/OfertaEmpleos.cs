using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class OfertaEmpleos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfEmpId { get; set; }
        public required string OfEmpTitulo { get; set; }
        public required string OfEmpSubTitulo { get; set; }
        public required string OfEmpDescripcion { get; set; }
        public required string OfEmpRequisitos { get; set; }
        public required string OfEmpTipoEmpleo { get; set; }
        public required string OfEmpModalidad { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal OfEmpSueldo { get; set; }
        public DateTime OfEmpFechaOferta { get; set; }
        public DateTime OfEmpFechaLimite { get; set; }
        //Localidad
        [ForeignKey("Provincia")]
        public int ProId { get; set; }
        public virtual Provincias Provincia { get; set; }
        //Empresa
        [ForeignKey("Empresa")]
        public int EmpId { get; set; }
        public virtual Empresas Empresa { get; set; }
        //Estados
        [ForeignKey("Estado")]
        public int EstId { get; set; }
        public virtual Estados Estado { get; set; }
    }
}
