namespace selecciontalento_api.DTOs
{
    public class ForgotUserRequest
    {
        public required string UsuNumDni { get; set; }
        public required string UsuEmail { get; set; }
        public required string UsuNumPhone { get; set; }
    }
}
