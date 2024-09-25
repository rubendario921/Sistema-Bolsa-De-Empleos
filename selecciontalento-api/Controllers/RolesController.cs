using Microsoft.AspNetCore.Mvc;
using selecciontalento_api.Services;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IServicesRoles _servicesRoles;
        //Constructor
        public RolesController(IServicesRoles servicesRoles)
        {
            _servicesRoles = servicesRoles;
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<ActionResult<IEnumerable<DTOs.RolesDTO>>> GetAllRoles()
        {
            var roles = await _servicesRoles.GetAllRoles();
            if (roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return NotFound("No hay información registrada");
            }
        }

        [HttpGet]
        [Route("GetAllRoles/{id}")]
        public async Task<ActionResult<DTOs.RolesDTO>> GetRolById(int id)
        {
            if (id > 0)
            {
                var rol = await _servicesRoles.GetRolesById(id);
                if (rol != null)
                {
                    return Ok(rol);
                }
                else
                {
                    return NotFound("No hay informacion registrada");
                }
            }
            else
            {
                return BadRequest("Error, campo Id incorrecto");
            }
        }

        [HttpPost]
        [Route("SaveRol")]
        public async Task<ActionResult<bool>> SaveRoles(DTOs.RolesDTO rolDTO)
        {
            if (rolDTO != null)
            {
                Models.Roles roleData = new()
                {
                    RolName = rolDTO.RolName,
                    RolDescription = rolDTO.RolDescription
                };
                var result = await _servicesRoles.SaveRol(roleData);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Rol ya registrado, intente nuevamente");
                }
            }
            else
            {
                return BadRequest("Datos vacios, verifique la informacion");
            }
        }

        [HttpPut]
        [Route("UpdateRol/{id}")]
        public async Task<ActionResult<bool>> UpdateRol(DTOs.RolesDTO rolesDTO)
        {

            if (rolesDTO != null)
            {
                Models.Roles rolData = new()
                { RolId = rolesDTO.RolId, RolName = rolesDTO.RolName, RolDescription = rolesDTO.RolDescription };
                var result = await _servicesRoles.UpdateRol(rolData);
                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Error en actualziar el Rol, intente nuevamente");
                }
            }
            else
            {
                return NotFound("Datos vacios, varifique la información.");
            }
        }

        [HttpDelete]
        [Route("DeleteRol/{id}")]
        public async Task<ActionResult<bool>> DeleteRol(int id)
        {
            if (id > 0)
            {
                var result = await _servicesRoles.DeleteRol(id);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Error al eliminar el Rol, intente nuevamente.");
                }
            }
            else
            {
                return NotFound($"No existe información con el id: {id}");
            }
        }
    }
}