namespace selecciontalento_api.DTOs
{
    public class UsuariosDTO
    {
        public int UsuId { get; set; }
        public required string UsuName { get; set; }
        public required string UsuLastName { get; set; }
        public required string UsuTypeDni { get; set; }
        public required string UsuNumDni { get; set; }
        public required string UsuNumPhone { get; set; }
        public required string UsuEmail { get; set; }
        public required string UsuPassword { get; set; }
        public int UsuAttempts { get; set; }
        public string? UsuProfilePicture { get; set; }
        public string? UsuAdicionalArchive { get; set; }
        public int RolId { get; set; }
        public int EstId { get; set; }
        //Informacion Adicional
        public string? RolName { get; set; }
        public string? EstadoName { get; set; }
        public string? EstadoColor { get; set; }
    }
}
