using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using selecciontalento_api.Models;
using selecciontalento_api.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace selecciontalento_api.Services
{
    public class ServicesAuthentication : IServicesAuthentication
    {
        //Extraer contexto de la base de datos
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        //Construcutor
        public ServicesAuthentication(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<Usuarios> GetUserByLogin(DTOs.LoginRequest loginRequest)
        {
            try
            {
                var dataUser = await AuthenticationUsuario(loginRequest.UsuNumDni, loginRequest.UsuPassword);
                if (dataUser == null)
                {
                    Console.WriteLine($"No existe usuario registrado.");
                    return null!;
                }
                else
                {
                    return dataUser;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetUserByLogin: {ex.Message}");
                throw;
            }
        }

        public async Task<Empresas> GetEmpresaByLogin(DTOs.LoginEmpresasDTO loginEmpresasDTO)
        {
            try
            {
                var result = await AuthenticationEmpresa(loginEmpresasDTO.EmpNumRuc, loginEmpresasDTO.EmpStaffPassword);
                if (result == null)
                {
                    throw new Exception($"Error, no existe informaicon con los datos ingresados");
                }
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetEmpresaByLogin: {ex.Message}");
                throw;
            }
        }

        private async Task<Empresas> AuthenticationEmpresa(string numRuc, string numPassword)
        {
            try
            {
                var result = await _dataContext.Empresas.Where(e => e.EmpNumRuc.Equals(numRuc) && e.EmpStaffPassword.Equals(numPassword)).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new Exception($"Error, no existe información");
                }
                return (result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en AuthenticationEmpresa: {ex.Message}");
                throw;
            }
        }




        private async Task<Usuarios> AuthenticationUsuario(string numDni, string password)
        {
            try
            {
                var dataUser = await _dataContext.Usuarios.Where(data => data.UsuNumDni.Equals(numDni) && data.UsuPassword.Equals(password)).Include(x => x.Rol).FirstOrDefaultAsync();
                return dataUser!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en AuthenticationUsuario: {ex.Message}");
                throw;
            }
        }

        public object generateToken(Models.Usuarios usuarios)
        {
            //Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                   Encoding.UTF8.GetBytes(_configuration["JWT:key"])
               );
            var _sigingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );

            var _Header = new JwtHeader(_sigingCredentials);
            //Claims - Publico
            var _claims = new[] {
             new Claim(JwtRegisteredClaimNames.NameId,usuarios.UsuId.ToString()),
             new Claim("nombre", usuarios.UsuName),
             new Claim("rol", usuarios.Rol.RolName),
             new Claim(JwtRegisteredClaimNames.Email, usuarios.UsuEmail),
     };
            //PayLoad
            var _Payload = new JwtPayload(
                    issuer: _configuration["JWT:Dominio"],
                    audience: _configuration["JWT:AppApi"],
                    claims: _claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(5)
                );
            //Token
            var _token = new JwtSecurityToken(_Header, _Payload);
            return new JwtSecurityTokenHandler().WriteToken(_token);


        }

        public async Task<bool> ForgotUsuario(DTOs.ForgotUserRequest forgotUser)
        {
            try
            {
                var dataUser = await ForgotUserById(forgotUser);
                if (dataUser == null)
                {
                    return false;
                }
                else
                {
                    dataUser.UsuPassword = "12345678";
                    _dataContext.Entry(dataUser).State = EntityState.Modified;
                    return await _dataContext.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async Task<Usuarios> ForgotUserById(DTOs.ForgotUserRequest forgotUser)
        {
            try
            {
                var dataUser = await _dataContext.Usuarios.Where(data => data.UsuNumDni.Equals(forgotUser.UsuNumDni) && data.UsuEmail.Equals(forgotUser.UsuEmail) && data.UsuNumPhone.Equals(forgotUser.UsuNumPhone)).FirstOrDefaultAsync();
                if (dataUser != null)
                {
                    return dataUser;
                }
                else
                {
                    throw new Exception("No existe usuario registrado");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
