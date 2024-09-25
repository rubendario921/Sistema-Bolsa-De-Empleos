using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Idiomas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdiId { get; set; }
        public required string IdiName { get; set; }        
        public virtual ICollection<CandidatoIdioma> CandidatoIdioma { get; set; } = [];
    }
}   