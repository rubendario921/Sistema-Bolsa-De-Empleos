using Microsoft.EntityFrameworkCore;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Services
{
    public class ServicesUsuarios : IServicesUsuarios
    {
        //Extraer contexto de la base de datos
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        //Construcutor
        public ServicesUsuarios(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }
        //Metodos
        public async Task<IEnumerable<DTOs.UsuariosDTO>> GetAllUsuarios()
        {
            try
            {
                var result = await _dataContext.Usuarios.Include(r => r.Rol).Include(e => e.Estado).Select(u => new DTOs.UsuariosDTO
                {
                    UsuId = u.UsuId,
                    UsuName = u.UsuName,
                    UsuLastName = u.UsuLastName,
                    UsuTypeDni = u.UsuTypeDni,
                    UsuNumDni = u.UsuNumDni,
                    UsuNumPhone = u.UsuNumPhone,
                    UsuEmail = u.UsuEmail,
                    UsuPassword = u.UsuPassword,
                    UsuAttempts = u.UsuAttempts,
                    UsuAdicionalArchive = u.UsuAdicionalArchive,
                    UsuProfilePicture = u.UsuProfilePicture,
                    EstId = u.EstId,
                    EstadoName = u.Estado.EstName,
                    EstadoColor = u.Estado.EstColor,
                    RolId = u.RolId,
                    RolName = u.Rol.RolName

                }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllUsuarios :{ex.Message}");
                throw;
            }
        }
        public async Task<DTOs.UsuariosDTO> GetUsuarioById(int id)
        {
            try
            {
                var result = await _dataContext.Usuarios.Include(u => u.Rol).Include(u => u.Estado).Where(u => u.UsuId.Equals(id)).Select(u => new DTOs.UsuariosDTO { UsuId = u.UsuId, UsuName = u.UsuName, UsuLastName = u.UsuLastName, UsuTypeDni = u.UsuTypeDni, UsuNumDni = u.UsuNumDni, UsuNumPhone = u.UsuNumPhone, UsuEmail = u.UsuEmail, UsuPassword = u.UsuPassword, UsuAttempts = u.UsuAttempts, UsuAdicionalArchive = u.UsuAdicionalArchive, UsuProfilePicture = u.UsuProfilePicture, EstId = u.EstId, RolId = u.RolId, EstadoName = u.Rol.RolName, RolName = u.Estado.EstName }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetUsuariosById :{ex.Message}");
                throw;
            }
        }
        public async Task<DTOs.UsuariosDTO> GetUsuarioByNumDni(string numDni)
        {
            try
            {
                var result = await _dataContext.Usuarios.Include(u => u.Rol).Where(u => u.UsuNumDni.Equals(numDni)).Select(u => new DTOs.UsuariosDTO { UsuId = u.UsuId, UsuName = u.UsuName, UsuLastName = u.UsuLastName, UsuTypeDni = u.UsuTypeDni, UsuNumDni = u.UsuNumDni, UsuNumPhone = u.UsuNumPhone, UsuEmail = u.UsuEmail, UsuPassword = u.UsuPassword, UsuAttempts = u.UsuAttempts, UsuAdicionalArchive = u.UsuAdicionalArchive, UsuProfilePicture = u.UsuProfilePicture, EstId = u.EstId, RolId = u.RolId, EstadoName = u.Rol.RolName, RolName = u.Estado.EstName }).FirstOrDefaultAsync();
                return result!;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetUsuarioByNumDni :{ex.Message}");
                throw;
            }
        }
        public async Task<bool> SaveUsuario(Models.Usuarios usuarios)
        {
            try
            {
                var dataUser = await GetUsuarioByNumDni(usuarios.UsuNumDni);
                if (dataUser == null)
                {
                    _dataContext.Usuarios.Add(usuarios);
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception($"Registro duplicado, intente nuevamente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SaveUsuarios: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateUsuario(Models.Usuarios usuarios)
        {
            try
            {
                var dataUser = await GetUsuarioById(usuarios.UsuId);
                if (dataUser != null)
                {
                    _dataContext.Entry(usuarios).State = EntityState.Modified;
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception($"No existe informacion por ID: {usuarios.UsuId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateUsuario: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var dataUser = await GetUsuarioById(id);
                if (dataUser != null)
                {
                    Models.Usuarios usuario = new()
                    {
                        UsuId = dataUser.UsuId,
                        UsuName = dataUser.UsuName,
                        UsuLastName = dataUser.UsuLastName,
                        UsuTypeDni = dataUser.UsuTypeDni,
                        UsuNumDni = dataUser.UsuNumDni,
                        UsuNumPhone = dataUser.UsuNumPhone,
                        UsuEmail = dataUser.UsuEmail,
                        UsuPassword = dataUser.UsuPassword,
                        UsuAttempts = dataUser.UsuAttempts,
                        UsuProfilePicture = dataUser.UsuProfilePicture,
                        UsuAdicionalArchive = dataUser.UsuAdicionalArchive,
                        RolId = dataUser.RolId,
                        EstId = 2
                    };

                    _dataContext.Entry(usuario).State = EntityState.Modified;
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception($"No existe información por el ID: {id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario: {ex.Message}");
                throw;
            }
        }
    }
}
