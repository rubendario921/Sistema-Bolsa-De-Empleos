using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using selecciontalento_api.Services;
using ZstdSharp.Unsafe;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustriasController : ControllerBase
    {
        private readonly IServicesIndustrias _servicesIndustrias;

        public IndustriasController(IServicesIndustrias servicesIndustrias)
        {
            _servicesIndustrias = servicesIndustrias;
        }

        [HttpGet]
        [Route("GetAllIndustrias")]
        public async Task<ActionResult<IEnumerator<DTOs.IndustriasDTO>>> GetAllIndustrias()
        {
            var result = await _servicesIndustrias.GetAllIndustrias();
            if (result == null)
            {
                return NotFound("No existen datos registrados");
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetIndustriaById")]
        public async Task<ActionResult<DTOs.IndustriasDTO>> GetIndustriaById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Campos Id: {id} vacio o incorrecto");
            }
            var result = await _servicesIndustrias.GetIndustriaById(id);
            if (result == null)
            {
                return NotFound($"Error, no existen datos por el ID: {id}");
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetIndustriaByName")]
        public async Task<ActionResult<DTOs.IndustriasDTO>> GetIndustriaByName(string name)
        {
            if (name == null)
            {
                return BadRequest($"Campos Nombre: {name} vacio o incorrecto");
            }
            var result = await _servicesIndustrias.GetIndustriaByName(name);
            if (result == null)
            {
                return NotFound($"Error, no existen datos por el ID: {name}");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveIndustria")]
        public async Task<ActionResult<bool>> SaveIndustria(DTOs.IndustriasDTO industriasDTO)
        {
            if (industriasDTO == null)
            {
                return BadRequest($"Campo industria {industriasDTO} vacios o incompleto.");
            }
            Models.Industrias industrias = new() { IndId = industriasDTO.IndId, IndName = industriasDTO.IndName, IndDetails = industriasDTO.IndDetails };
            var result = await _servicesIndustrias.SaveIndustria(industrias);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest($"Error, en registrar nuevo usuario, intenten nuevamente.");
            }
        }

        [HttpPut]
        [Route("UpdateIndustria")]
        public async Task<ActionResult<bool>> UpdateIndustria(DTOs.IndustriasDTO industriasDTO)
        {
            if (industriasDTO == null)
            {
                return BadRequest($"Campo industria {industriasDTO} vacios o incompleto.");
            }
            Models.Industrias industrias = new() { IndId = industriasDTO.IndId, IndName = industriasDTO.IndName, IndDetails = industriasDTO.IndDetails };
            var result = await _servicesIndustrias.SaveIndustria(industrias);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest($"Error, en actualizar el usuario, intenten nuevamente.");
            }
        }

        [HttpDelete]
        [Route("DeleteIndustria")]
        public async Task<ActionResult<bool>> DeleteIndustria(DTOs.IndustriasDTO industriasDTO)
        {
            if (industriasDTO == null)
            {
                return BadRequest($"Campo industria {industriasDTO} vacios o incompleto.");
            }

            var result = await _servicesIndustrias.DeleteIndustria(industriasDTO.IndId);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest($"Error, en eliminar el usuario, intenten nuevamente.");
            }
        }
    }
}
