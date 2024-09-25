using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selecciontalento_api.DTOs
{
    public class RolesDTO
    {
        public int RolId { get; set; }
        public required string RolName { get; set; }
        public string? RolDescription { get; set; }
    }
}