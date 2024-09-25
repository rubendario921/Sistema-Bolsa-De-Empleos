using K4os.Compression.LZ4.Streams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using selecciontalento_api.DTOs;
using selecciontalento_api.Services;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdiomasController(IServicesIdiomas servicesIdiomas) : ControllerBase
    {
        private readonly IServicesIdiomas _servicesIdiomas = servicesIdiomas;

        [HttpGet]
        [Route("GetAllIdiomas")]
        public async Task<ActionResult<IEnumerable<IdiomasDTO>>> GetAllIdiomas()
        {
            var idiomas = await _servicesIdiomas.GetAllIdiomas();
            if (idiomas == null) { return NotFound("Sin informacion de idiomas"); }
            return Ok(idiomas);
        }

        [HttpGet]
        [Route("GetIdiomaById/{id}")]
        public async Task<ActionResult<EstadosDTO>> GetIdiomasById(int id)
        {
            if (id < 0)
            {
                return NotFound("Error en el id vacio o incorrecto");
            }
            var idiomas = await _servicesIdiomas.GetIdiomaById(id);
            if (idiomas == null)
            {
                return NotFound("No existe informacion registrqada por el ID");
            }
            return Ok(idiomas);
        }

        [HttpPost]
        [Route("SaveIdiomas")]
        public async Task<ActionResult<bool>> SaveIdiomas(IdiomasDTO idiomasDTO)
        {
            if (idiomasDTO == null)
            {
                return BadRequest("Campos vacios o incorrectos.");
            }
            Models.Idiomas idiomas = new() { IdiName = idiomasDTO.IdiName };
            var result = await _servicesIdiomas.SaveIdioma(idiomas);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest("Error en registrar Idiomas.");
            }
        }

        [HttpPut]
        [Route("UpdateIdiomas/{id}")]
        public async Task<ActionResult<bool>> UpdateIdiomas(IdiomasDTO idiomasDTO, int id)
        {
            if (id <= 0)
            {
                return BadRequest("Campos Id vacios o incorrectos");
            }
            if (idiomasDTO == null)
            {
                return BadRequest("Campos idiomasDTO vacios o incorrectos");
            }
            Models.Idiomas idiomas = new() { IdiId = id, IdiName = idiomasDTO.IdiName };
            var result = await _servicesIdiomas.UpdateIdioma(idiomas);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest("Error en actualizar el idiomas");
            }
        }

        [HttpDelete]
        [Route("DeleteIdiomas/{id}")]
        public async Task<ActionResult<bool>> DeleteIdiomas(IdiomasDTO idiomasDTO, int id)
        {
            if (id <= 0)
            {
                return BadRequest("Campos Id vacios o incorrectos");
            }
            if (idiomasDTO == null)
            {
                return BadRequest("Campos idiomasDTO vacios o incorrectos");
            }
            Models.Idiomas idiomas = new Models.Idiomas() { IdiId = id, IdiName = idiomasDTO.IdiName };
            var result = await _servicesIdiomas.DeleteIdioma(idiomas.IdiId);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest("Error a eliminar el idiomas.");
            }
        }

    }
}
