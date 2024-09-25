using selecciontalento_api.DTOs;

namespace selecciontalento_api.Services
{
    public interface IServicesRoles
    {
        Task<IEnumerable<DTOs.RolesDTO>> GetAllRoles();
        Task<DTOs.RolesDTO> GetRolesById(int id);
        Task<DTOs.RolesDTO> GetRolesByName(string name);
        Task<bool> SaveRol(Models.Roles roles);
        Task<bool> UpdateRol(Models.Roles roles);
        Task<bool> DeleteRol(int id);
    }
}
