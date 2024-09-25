using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using selecciontalento_api.Services;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly IServicesProvincias _servicesProvincias;

        public ProvinciasController(IServicesProvincias servicesProvincias)
        {
            _servicesProvincias = servicesProvincias;
        }

        [HttpGet]
        [Route("GetAllProvincias")]
        public async Task<ActionResult<IEnumerable<Models.Provincias>>> GetAllProvincias() { 
            var result = await _servicesProvincias.GetAllProvincias();
            if (result == null) {
                return BadRequest($"No existe informacion registrada");
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetProvinciaById/{id}")]
        public async Task<ActionResult<Models.Provincias>> GetProvinciaById(int id) {
            if (id <= 0) {
                return BadRequest($"Error, campo Id:{id} vacio o incorrecto");
            }
            var result = await _servicesProvincias.GetProvinciaById(id);
            if (result == null) {
                return BadRequest($"No existe informacion por Id:{id}");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("SaveProvincia")]
        public async Task<ActionResult<bool>> SaveProvincia(Models.Provincias provincia)
        {
            if (provincia == null)
            {
                return BadRequest($"Error, campos vacios o incorrectos");
            }
            var consult = await _servicesProvincias.GetProvinciaByName(provincia.ProdName);
            if (consult != null)
            {
                return BadRequest($"Error, dato duplicado. Intente nuevamente");
            }
            var result = await _servicesProvincias.SaveProvincia(provincia);
            if (!result)
            {
                return BadRequest($"Error en guardar datos");
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateProvincia/{id}")]
        public async Task<ActionResult<bool>> UpdateProvincia(int id,Models.Provincias provincia)
        {
            if (id <= 0) {
                return BadRequest($"Error, campo Id {id} vacio o incorrecto");
            }
            if (provincia == null)
            {
                return BadRequest($"Error, campos vacios o incorrectos");
            }
            var consult = await _servicesProvincias.GetProvinciaById(id);
            if (consult == null)
            {
                return BadRequest($"Error, no existe informacion por Id:{id}");
            }
            Models.Provincias provinciaData = new() { ProId = provincia.ProId, ProdName = provincia.ProdName, ProdCapital = provincia.ProdCapital };
            var result = await _servicesProvincias.SaveProvincia(provinciaData);
            if (!result)
            {
                return BadRequest($"Error en guardar datos");
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteProvincia/{id}")]
        public async Task<ActionResult<bool>> DeleteProvincia(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Error, campo Id {id} vacio o incorrecto");
            }            
            var consult = await _servicesProvincias.GetProvinciaById(id);
            if (consult == null)
            {
                return BadRequest($"Error, no existe informacion por Id:{id}");
            }            
            var result = await _servicesProvincias.DeleteProvincia(consult.ProId);
            if (!result)
            {
                return BadRequest($"Error en eliminar el registro");
            }
            return Ok(result);
        }
    }
}
