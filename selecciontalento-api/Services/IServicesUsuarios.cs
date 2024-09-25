using selecciontalento_api.Models;

namespace selecciontalento_api.Services
{
    public interface IServicesUsuarios
    {
        Task<IEnumerable<DTOs.UsuariosDTO>> GetAllUsuarios();
        Task<DTOs.UsuariosDTO> GetUsuarioById(int id);
        Task<DTOs.UsuariosDTO> GetUsuarioByNumDni(string numDni);
        Task<bool> SaveUsuario(Models.Usuarios usuarios);
        Task<bool> UpdateUsuario(Models.Usuarios usuarios);
        Task<bool> DeleteUser(int id);
    }
}
