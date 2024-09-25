using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Provincias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProId { set; get; }
        public required string ProdName { set; get; }
        public required string ProdCapital { set; get; }
        public virtual ICollection<OfertaEmpleos> OfertaEmpleos { set; get; } = new List<OfertaEmpleos>();
    }
}
