using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RolId { get; set; }
        [StringLength(50)]
        public required string RolName { get; set; }
        [StringLength(100)]
        public string? RolDescription { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; } = [];
    }
}
