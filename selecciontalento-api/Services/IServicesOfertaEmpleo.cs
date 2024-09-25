using selecciontalento_api.DTOs;

namespace selecciontalento_api.Services
{
    public interface IServicesOfertaEmpleo
    {
        Task<IEnumerable<OfertaEmpleoDTO>> GetAllOfertaEmpleos();
        Task<OfertaEmpleoDTO> GetOfertaEmpleoById(int id);
        Task<OfertaEmpleoDTO> GetOfertaEmpleoByTitutlo(string? name);        
        Task<bool> SaveOfertaEmpleo(Models.OfertaEmpleos ofertaEmpleos);
        Task<bool> UpdateOfertaEmpleo(Models.OfertaEmpleos ofertaEmpleos);
        Task<bool> DeleteOfertaEmpleo(int id);
    }
}
    