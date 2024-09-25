using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class CantidadEmpleados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CantEmpId { get; set; }
        public required string CantEmpDetails { get; set; }
        public virtual ICollection<Empresas> Empresas { get; set; } = [];
    }
}
