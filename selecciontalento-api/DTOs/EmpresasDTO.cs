using selecciontalento_api.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace selecciontalento_api.DTOs
{
    public class EmpresasDTO
    {
        public int EmpId { get; set; }
        public required string EmpStaffName { get; set; }
        public required string EmpStaffLastName { get; set; }        
        public required string EmpStaffEmail { get; set; }
        public required string EmpStaffPassword { get; set; }
        public required string EmpName { get; set; }
        public required string EmpRazonSocial { get; set; }        
        public required string EmpNumRuc { get; set; }
        public required string EmpDireccion { get; set; }
        public required string EmpCodPostal { get; set; }        
        public required string EmpNumPhone { get; set; }        
        public string? EmpProfilePicture { get; set; }
        //Informacion Adicional
        public int EstId { get; set; }
        public string? EstName { get; set; }
        public string? EstColor { get; set; }
        //Industrias
        public int IndId { get; set; }
        public string? IndName { get; set; }
        //Canitdad de empleaos
        public int CantEmpID { get; set; }
        public string? CantEmpDetails { get; set; }
    }
}
