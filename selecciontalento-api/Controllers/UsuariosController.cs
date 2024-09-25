using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using selecciontalento_api.Models;
using selecciontalento_api.Services;
using selecciontalento_api.DTOs;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //Contexto de base de datos
        private readonly IServicesUsuarios _servicesUsuarios;
        //Constructor
        public UsuariosController(IServicesUsuarios servicesUsuarios)
        {
            _servicesUsuarios = servicesUsuarios;
        }

        [HttpGet]
        [Route("GetAllUsuarios")]
        public async Task<ActionResult<IEnumerable<DTOs.UsuariosDTO>>> GetAllUsuarios()
        {
            var usuarios = await _servicesUsuarios.GetAllUsuarios();
            if (usuarios != null)
            {
                return Ok(usuarios);
            }
            else
            {
                return NotFound("No hay datos de Usuarios");
            }
        }

        [HttpGet]
        [Route("GetUsuarioById/{id}")]
        public async Task<ActionResult<DTOs.UsuariosDTO>> GetUsuariosById(int id)
        {
            if (id > 0)
            {
                var usuario = await _servicesUsuarios.GetUsuarioById(id);
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return NotFound($"No existe información con el Id: {id}");
                }
            }
            else
            {
                return NotFound($"Campo ID {id} incorrecto o vacio.");
            }
        }
        [HttpPost]
        [Route("SaveUsuarios")]
        public async Task<ActionResult<bool>> SaveUsuarios(DTOs.UsuariosDTO usuariosRequest)
        {
            if (usuariosRequest != null)
            {
                Models.Usuarios usuarioData = new()
                {
                    UsuId = usuariosRequest.UsuId,
                    UsuName = usuariosRequest.UsuName,
                    UsuLastName = usuariosRequest.UsuLastName,
                    UsuTypeDni = usuariosRequest.UsuTypeDni,
                    UsuNumDni = usuariosRequest.UsuNumDni,
                    UsuNumPhone = usuariosRequest.UsuNumPhone,
                    UsuEmail = usuariosRequest.UsuEmail,
                    UsuPassword = usuariosRequest.UsuPassword,
                    UsuAttempts = usuariosRequest.UsuAttempts,
                    UsuProfilePicture = usuariosRequest.UsuProfilePicture,
                    UsuAdicionalArchive = usuariosRequest.UsuAdicionalArchive,
                    RolId = usuariosRequest.RolId,
                    EstId = usuariosRequest.EstId
                };
                var result = await _servicesUsuarios.SaveUsuario(usuarioData);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound($"Usuario ya existe, ingrese los datos correctamente");
                }
            }
            else
            {
                return NotFound($"Datos vacios, verifique la información.");
            }
        }
        [HttpPut]
        [Route("UpdateUsuario/{id}")]
        public async Task<ActionResult<bool>> UpdateUsuario(int id,DTOs.UsuariosDTO usuariosRequest)
        {
            if (id > 0)
            {
                if (usuariosRequest != null)
                {
                    Models.Usuarios usuarioData = new Usuarios
                    {
                        UsuId = usuariosRequest.UsuId,
                        UsuName = usuariosRequest.UsuName,
                        UsuLastName = usuariosRequest.UsuLastName,
                        UsuTypeDni = usuariosRequest.UsuTypeDni,
                        UsuNumDni = usuariosRequest.UsuNumDni,
                        UsuNumPhone = usuariosRequest.UsuNumPhone,
                        UsuEmail = usuariosRequest.UsuEmail,
                        UsuPassword = usuariosRequest.UsuPassword,
                        UsuAttempts = usuariosRequest.UsuAttempts,
                        UsuProfilePicture = usuariosRequest.UsuProfilePicture,
                        UsuAdicionalArchive = usuariosRequest.UsuAdicionalArchive,
                        RolId = usuariosRequest.RolId,
                        EstId = usuariosRequest.EstId
                    };

                    var result = await _servicesUsuarios.UpdateUsuario(usuarioData);
                    if (result)
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return NotFound($"Error al actualizar el usuario, ingrese los datos correctamente.");
                    }
                }
                else
                {
                    return NotFound($"Datos de usuario es nulo.");
                }
            }
            else { 
                return BadRequest($"El campo ID {id} esta vacio o incorrecto.");
            }
        }
        [HttpDelete]
        [Route("DeleteUsuario/{id}")]
        public async Task<ActionResult<bool>> DeleteUsuario(int id)
        {
            if (id > 0)
            {
                var result = await _servicesUsuarios.DeleteUser(id);
                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound("Error al eliminar el usuario, intente nuevamente.");
                }
            }
            else {
                return NotFound($"No existe el id: {id} ingresado");
            }
        }
    }
}