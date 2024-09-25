using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Estados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstId { get; set; }
        [StringLength(50)]
        public required string EstName { get; set; }
        [StringLength(100)]
        public required string EstCategory { get; set; }
        [StringLength(30)]
        public required string EstColor { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
        public virtual ICollection<Empresas> Empresas { get; set; } = new List<Empresas>();
        public virtual ICollection<OfertaEmpleos> OfertaEmpleos { get; set; } = new List<OfertaEmpleos>();
    }
}