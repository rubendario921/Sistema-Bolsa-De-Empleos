namespace selecciontalento_api.DTOs
{
    public class EstadosDTO
    {
        public class EstadoRequest
        {
            public int EstId { get; set; }
            public required string EstName { get; set; }
            public required string EstCategory { get; set; }
            public required string EstColor { get; set; }
        }
        public class EstadosResponse
        {
            public int EstId { get; set; }
            public required string EstName { get; set; }
            public required string EstCategory { get; set; }
            public required string EstColor { get; set; }
        }
    }
}
