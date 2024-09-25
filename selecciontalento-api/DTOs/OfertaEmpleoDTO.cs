using selecciontalento_api.Models;

namespace selecciontalento_api.DTOs
{
    public class OfertaEmpleoDTO
    {
        public int OfEmpId { get; set; }
        public required string OfEmpTitulo { get; set; }
        public required string OfEmpSubTitulo { get; set; }
        public required string OfEmpDescripcion { get; set; }
        public required string OfEmpRequisitos { get; set; }
        public required string OfEmpTipoEmpleo { get; set; }
        public required string OfEmpModalidad { get; set; }
        public Decimal OfEmpSueldo { get; set; }
        public DateTime OfEmpFechaOferta { get; set; }
        public DateTime OfEmpFechaLimite { get; set; }
        //Localidad
        public int ProId { get; set; }
        public string? ProName { get; set; }
        public string? ProCapital { get; set; }
        //Empresa
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        //Estados
        public int EstId { get; set; }
        public string? EstNombre { get; set; }
        public string? EstColor { get; set; }
    }
}
