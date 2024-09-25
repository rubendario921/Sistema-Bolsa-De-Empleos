using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Identity.Client;
using selecciontalento_api.Models;
using selecciontalento_api.Services;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IServicesEmpresas _servicesEmpresas;
        public EmpresasController(IServicesEmpresas servicesEmpresas)
        {
            _servicesEmpresas = servicesEmpresas;
        }

        [HttpGet]
        [Route("GetAllEmpresas")]
        public async Task<ActionResult<IEnumerable<DTOs.EmpresasDTO>>> GetAllEmpresas()
        {
            var empresas = await _servicesEmpresas.GetAllEmpresas();
            if (empresas != null)
            {
                return Ok(empresas);
            }
            else
            {
                return NotFound("No hay datos registados.");
            }
        }
        [HttpGet]
        [Route("GetEmpresaById/{id}")]
        public async Task<ActionResult<DTOs.EmpresasDTO>> GetEmpresaById(int id)
        {
            if (id > 0)
            {
                var usuario = await _servicesEmpresas.GetEmpresaById(id);
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return NotFound($"No existe información con el ID:{id}");
                }
            }
            else
            {
                return NotFound($"Campo Id {id} es incorrecto o vacio.");
            }
        }
        [HttpPost]
        [Route("SaveEmpresa")]
        public async Task<ActionResult<bool>> SaveEmpresa(DTOs.EmpresasDTO empresaDTO)
        {
            if (empresaDTO != null)
            {
                Models.Empresas empresa = new() {
                    EmpStaffName = empresaDTO.EmpStaffName,
                    EmpStaffLastName = empresaDTO.EmpStaffLastName,
                    EmpStaffEmail = empresaDTO.EmpStaffEmail,
                    EmpStaffPassword = empresaDTO.EmpStaffPassword,
                    EmpName = empresaDTO.EmpName,
                    EmpRazonSocial = empresaDTO.EmpRazonSocial,
                    EmpNumRuc = empresaDTO.EmpNumRuc,
                    EmpDireccion = empresaDTO.EmpDireccion,
                    EmpCodPostal = empresaDTO.EmpCodPostal,
                    EmpNumPhone = empresaDTO.EmpNumPhone,
                    EmpProfilePicture = empresaDTO.EmpProfilePicture,
                    EstId = empresaDTO.EstId,
                    IndId = empresaDTO.IndId,
                    CantEmpId = empresaDTO.CantEmpID,                    
                };
                var result = await _servicesEmpresas.SaveEmpresa(empresa);
                if (result) { return Ok(result); } else { return BadRequest($"Error, empresa ya registrada, verifique los datos correctamente."); }
            }
            else
            {
                return BadRequest($"Datos vacios, verifique la informacion e intente nuevamente.");
            }
        }

        [HttpPut]
        [Route("UpdateEmpresa/{id}")]
        public async Task<ActionResult<bool>> UpdateEmpresa(int id, DTOs.EmpresasDTO empresaDTO)
        {
            if (id > 0)
            {
                var result = await _servicesEmpresas.GetEmpresaById(id);
                if (result != null)
                {
                    if (empresaDTO != null)
                    {
                        Models.Empresas empresas = new()
                        {
                            EmpStaffName = empresaDTO.EmpStaffName,
                            EmpStaffLastName = empresaDTO.EmpStaffLastName,
                            EmpStaffEmail = empresaDTO.EmpStaffEmail,
                            EmpStaffPassword = empresaDTO.EmpStaffPassword,
                            EmpName = empresaDTO.EmpName,
                            EmpRazonSocial = empresaDTO.EmpRazonSocial,
                            EmpNumRuc = empresaDTO.EmpNumRuc,
                            EmpDireccion = empresaDTO.EmpDireccion,
                            EmpCodPostal = empresaDTO.EmpCodPostal,
                            EmpNumPhone = empresaDTO.EmpNumPhone,                            
                            EmpProfilePicture = empresaDTO.EmpProfilePicture,
                            EstId = empresaDTO.EstId,
                            IndId = empresaDTO.IndId,
                            
                        };
                        var update = await _servicesEmpresas.UpdateEmpresa(empresas);
                        if (update)
                        {
                            return Ok(update);
                        }
                        else
                        {
                            return BadRequest($"Error al actualizar la empresa, ingrese los datos correctamente");
                        }
                    }
                    else
                    {
                        return BadRequest($"Error, campos vacios o incorrectos.");
                    }
                }
                else
                {
                    return BadRequest($"Error, no existe información con el ID: {id}");
                }
            }
            else
            {
                return BadRequest($"Error, campo vacio o incorrecto en el  ID: {id}");
            }
        }
        [HttpDelete]
        [Route("DeleteEmpresa/{id}")]
        public async Task<ActionResult<bool>> DeleteEmpresa(int id) {
            if (id > 0)
            {
                var result = await _servicesEmpresas.DeleteEmpresa(id);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest($"Error al eliminar el usuario, intente nuevamente");
                }
            }
            else {
                return BadRequest($"No existe informacion con el Id: {id}");
            }
        }
    }
}
