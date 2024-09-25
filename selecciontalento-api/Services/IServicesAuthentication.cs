using selecciontalento_api.Models;

namespace selecciontalento_api.Services
{
    public interface IServicesAuthentication
    {
        Task<Models.Usuarios> GetUserByLogin(DTOs.LoginRequest loginRequest);
        Task<Models.Empresas> GetEmpresaByLogin(DTOs.LoginEmpresasDTO loginEmpresasDTO);
        object generateToken(Models.Usuarios usuarios);
        Task<bool> ForgotUsuario(DTOs.ForgotUserRequest forgotUser);
    }
}
