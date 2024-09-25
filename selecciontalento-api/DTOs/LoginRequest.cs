namespace selecciontalento_api.DTOs
{
    public class LoginRequest
    {
        public required string UsuNumDni { get; set; }
        public required string UsuPassword { get; set; }
    }
}
