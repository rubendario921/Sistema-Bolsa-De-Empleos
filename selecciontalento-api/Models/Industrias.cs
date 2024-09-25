using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Industrias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndId { get; set; }
        public required string IndName { get; set; }
        public required string IndDetails { get; set; }
        public virtual ICollection<Empresas> Empresas { get; set; } = [];
    }
}
