using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using selecciontalento_api.DTOs;
using selecciontalento_api.Models;
using selecciontalento_api.Services;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("PolicyLocal")]
    public class AuthenticationController : ControllerBase
    {
        //Instancias
        public readonly IServicesAuthentication _servicesAuthentication;
        public readonly IServicesUsuarios _servicesUsuarios;
        public readonly IServicesEmpresas _servicesEmpresas;
        //Constructor
        public AuthenticationController(IServicesAuthentication servicesAuthentication, IServicesUsuarios servicesUsuarios, IServicesEmpresas servicesEmpresas)
        {
            _servicesAuthentication = servicesAuthentication;
            _servicesUsuarios = servicesUsuarios;
            _servicesEmpresas = servicesEmpresas;
        }

        [HttpPost]
        [Route("/api/auth")]

        public async Task<ActionResult> LoginUsuarios(LoginRequest dataLogin)
        {
            var dataUser = await _servicesAuthentication.GetUserByLogin(dataLogin);
            if (dataUser == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new
                {
                    usuId = dataUser.UsuId,
                    usuName = dataUser.UsuName,
                    usuLastName = dataUser.UsuLastName,
                    usuNumDni = dataUser.UsuNumDni,
                    rolName = dataUser.Rol.RolName,
                    usuToken = _servicesAuthentication.generateToken(dataUser),
                });
            }
        }
        [HttpPut]
        [Route("/api/forgotUser")]
        public async Task<ActionResult> ForgotUser(ForgotUserRequest forgotUser)
        {
            try
            {
                if (forgotUser == null)
                {
                    return BadRequest("Datos ingresados son nulos.");
                }
                else
                {
                    var dataUser = await _servicesAuthentication.ForgotUsuario(forgotUser);
                    if (dataUser)
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return NotFound("Error en actualizar la contraseña");
                    }
                }
            }
            catch (Exception ex)
            {
                return NotFound($"Error en actualizar la contraseña, error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("AuthEmpresas")]

        public async Task<ActionResult> AuthEmpresas(DTOs.LoginEmpresasDTO loginEmpresasDTO)
        {
            if (loginEmpresasDTO == null) {
                return BadRequest($"Error, campos vacios o incorrectos");
            }

            var result = await _servicesAuthentication.GetEmpresaByLogin(loginEmpresasDTO);
            if (result == null) {
                return NotFound($"No existe usuario registrado.");
            }
            return Ok(result);
            //if (dataUser == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return Ok(new
            //    {
            //        usuId = dataUser.UsuId,
            //        usuName = dataUser.UsuName,
            //        usuLastName = dataUser.UsuLastName,
            //        usuNumDni = dataUser.UsuNumDni,
            //        rolName = dataUser.Rol.RolName,
            //        usuToken = _servicesAuthentication.generateToken(dataUser),
            //    });
            //}
        }

    }
}