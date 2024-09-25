using Org.BouncyCastle.Bcpg.OpenPgp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Empresas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        public required string EmpStaffName { get; set; }
        public required string EmpStaffLastName { get; set; }
        [EmailAddress]
        public required string EmpStaffEmail { get; set; }
        public required string EmpStaffPassword { get; set; }
        public required string EmpName { get; set; }
        public required string EmpRazonSocial { get; set; }
        [StringLength(13)]
        public required string EmpNumRuc { get; set; }
        public required string EmpDireccion { get; set; }
        public required string EmpCodPostal { get; set; }
        [Phone]
        [StringLength(10)]
        public required string EmpNumPhone { get; set; }                
        public string? EmpProfilePicture { get; set; }
        //Tabla Estados
        public int EstId { get; set; }
        public virtual Estados Estado {  get; set; }
        //Tabla Industias
        public int IndId { get; set; }
        public virtual Industrias Industria { get; set; }
        //Tabla Cantidad Empleados
        public int CantEmpId { get; set; }
        public virtual CantidadEmpleados CantidadEmpleado { get; set; }
        public virtual ICollection<OfertaEmpleos> OfertaEmpleos { get; set; } = [];

        
    }
}
