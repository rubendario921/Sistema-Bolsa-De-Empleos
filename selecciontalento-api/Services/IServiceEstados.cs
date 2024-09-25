using selecciontalento_api.DTOs;
using selecciontalento_api.Models;

namespace selecciontalento_api.Services
{
    public interface IServiceEstados
    {
        Task<IEnumerable<EstadosDTO.EstadosResponse>> GetAllEstados();
        Task<EstadosDTO.EstadosResponse> GetEstadosById(int id);
        Task<EstadosDTO.EstadosResponse> GetEstadosByName(string? name);
        Task<EstadosDTO.EstadosResponse> GetEstadosByCategory(string? category);
        Task<bool> SaveEstados(Models.Estados estados);
        Task<bool> UpdateEstados(Models.Estados estados);
        Task<bool> DeleteEsteados(int id);
    }
}
