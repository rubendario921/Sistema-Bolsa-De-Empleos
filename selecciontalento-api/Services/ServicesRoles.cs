using Microsoft.EntityFrameworkCore;
using selecciontalento_api.DTOs;
using selecciontalento_api.Models;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Services
{
    public class ServicesRoles : IServicesRoles
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        //Constructor
        public ServicesRoles(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        //Metodos
        public async Task<IEnumerable<DTOs.RolesDTO>> GetAllRoles()
        {
            try
            {
                var result = await _dataContext.Roles.Select(r => new RolesDTO { RolId = r.RolId, RolName = r.RolName, RolDescription = r.RolDescription }).ToListAsync();
                if (result.Count != 0)
                {
                    return result;
                }
                else
                {
                    throw new Exception("No hay información de Roles registrados.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllRoles: {ex.Message}");
                throw;
            }
        }

        public async Task<DTOs.RolesDTO> GetRolesById(int id)
        {
            try
            {
                var result = await _dataContext.Roles.Select(r => new RolesDTO { RolId = r.RolId, RolName = r.RolName, RolDescription = r.RolDescription }).Where(dataRol => dataRol.RolId.Equals(id)).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetRolesById{ex.Message}");
                throw;
            }
        }
        public async Task<DTOs.RolesDTO> GetRolesByName(string name)
        {
            try
            {
                var result = await _dataContext.Roles.Select(r => new RolesDTO { RolId = r.RolId, RolName = r.RolName, RolDescription = r.RolDescription }).Where(dataRol => dataRol.RolName.Equals(name)).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetRolesByName: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> SaveRol(Roles rol)
        {
            try
            {
                var dataRol = await GetRolesByName(rol.RolName);
                if (dataRol == null)
                {
                    _dataContext.Roles.Add(rol);
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception("Error, Registro Duplicado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SaveRoles: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateRol(Models.Roles rol)
        {
            try
            {
                var result = await GetRolesById(rol.RolId);
                if (result != null)
                {
                    _dataContext.Entry(rol).State = EntityState.Modified;
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception($"No existe datos por ID {rol.RolId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error en UpdateRoles: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteRol(int id)
        {
            try
            {
                var dataRol = await GetRolesById(id);
                if (dataRol != null)
                {
                    Models.Roles rol = new() { RolId = dataRol.RolId, RolName = dataRol.RolName, RolDescription = dataRol.RolDescription };

                    _dataContext.Roles.Remove(rol);
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception("Error, no existe informacion por el Id.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteRoles {ex.Message}");
                throw;
            }
        }
    }
}
