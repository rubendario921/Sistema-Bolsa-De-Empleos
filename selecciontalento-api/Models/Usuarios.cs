using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.Models
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuId { get; set; }
        [StringLength(250)]
        public required string UsuName { get; set; }
        [StringLength(250)]
        public required string UsuLastName { get; set; }
        [StringLength(2)]
        public required string UsuTypeDni { get; set; }
        [StringLength(10)]
        public required string UsuNumDni { get; set; }
        [StringLength(10)]
        [Phone]
        public required string UsuNumPhone { get; set; }
        [StringLength(250)]
        [EmailAddress]
        public required  string UsuEmail { get; set; }
        public required string UsuPassword { get; set; }
        public required int UsuAttempts { get; set; }
        public string? UsuProfilePicture { get; set; }
        public string? UsuAdicionalArchive { get; set; }
        //Tabla Rol
        public int RolId { get; set; }
        public virtual Roles Rol { get; set; }
        //Table Estados
        public int EstId { get; set; }
        public virtual Estados Estado { get; set; }
    }
}
