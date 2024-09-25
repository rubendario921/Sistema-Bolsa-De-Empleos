using selecciontalento_api.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace selecciontalento_api.DTOs
{
    public class CandidatosDTO
    {
        public int CanId { get; set; }
        public required string CanNombre { get; set; }        
        public required string CanApellido { get; set; }        
        public required string CanNacionalidad { get; set; }
        public DateOnly FechaNacimiento { get; set; }        
        public required string CanEstadoCivil { get; set; }        
        public required string CanTipoDni { get; set; }        
        public required string CanNumDni { get; set; }
        public required string CanPassword { get; set; }        
        public required string CanGenero { get; set; }        
    }
}
