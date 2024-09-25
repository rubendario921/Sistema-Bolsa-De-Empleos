using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using selecciontalento_api.Services;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatosController(IServicesCandidatos servicesCandidatos) : ControllerBase
    {
        //Contexto de servicio
        private readonly IServicesCandidatos _servicesCandidatos = servicesCandidatos;

        [HttpGet]
        [Route("GetAllCandidatos")]
        public async Task<ActionResult<IEnumerable<DTOs.CandidatosDTO>>> GetAllCandidatos()
        {
            var result = await _servicesCandidatos.GetAllCandidatos();
            if (result == null)
            {
                return NotFound("No se encontraron datos registrados");
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetCandidatoById")]
        public async Task<ActionResult<DTOs.CandidatosDTO>> GetCandidatoById(int id)
        {
            if (id <= 0)
            {
                return NotFound($"Campos ID: {id} vacio o incorrecto.");
            }
            var result = await _servicesCandidatos.GetCandidatoById(id);
            if (result == null)
            {
                return NotFound($"No se encontraron datos registrados por ID: {id}");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveCandidato")]
        public async Task<ActionResult<bool>> SaveCandidato(DTOs.CandidatosDTO candidatoDTO)
        {
            if (candidatoDTO == null)
            {
                return BadRequest($"Campos vacios o incorrectos.");
            }

            var result = await _servicesCandidatos.GetCandidatoByNumDni(candidatoDTO.CanNumDni);
            if (result != null)
            {
                BadRequest($"Registro duplicado por DNI: {candidatoDTO.CanNumDni}");
            }

            Models.Candidatos candidato = new()
            {
                CanNombre = candidatoDTO.CanNombre,
                CanApellido = candidatoDTO.CanApellido,
                CanNacionalidad = candidatoDTO.CanNacionalidad,
                FechaNacimiento = candidatoDTO.FechaNacimiento,
                CanEstadoCivil = candidatoDTO.CanEstadoCivil,
                CanTipoDni = candidatoDTO.CanTipoDni,
                CanNumDni = candidatoDTO.CanNumDni,
                CanPassword = candidatoDTO.CanPassword,
                CanGenero = candidatoDTO.CanGenero,
            };
            await _servicesCandidatos.SaveCandidato(candidato); 
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateCandidato/{id}")]
        public async Task<ActionResult<bool>> UpdateCandidato(int id, DTOs.CandidatosDTO candidatoDTO)
        {
            if (id <= 0) {
                return BadRequest($"Campo ID: {id} vacio o incorrecto.");
            }
            if (candidatoDTO == null) {
                return BadRequest($"Campos candidato vacios o incorrectos");
            }
            var result = await _servicesCandidatos.GetCandidatoById(id);
            if (result == null) { 
                return NotFound($"Sin informacion por el Id: {id}");
            }
            Models.Candidatos candidato = new()
            {
                CanNombre = candidatoDTO.CanNombre,
                CanApellido = candidatoDTO.CanApellido,
                CanNacionalidad = candidatoDTO.CanNacionalidad,
                FechaNacimiento = candidatoDTO.FechaNacimiento,
                CanEstadoCivil = candidatoDTO.CanEstadoCivil,
                CanTipoDni = candidatoDTO.CanTipoDni,
                CanNumDni = candidatoDTO.CanNumDni,
                CanPassword = candidatoDTO.CanPassword,
                CanGenero = candidatoDTO.CanGenero,
                //Estado                
            };
            await _servicesCandidatos.UpdateCandidato(candidato);
            return Ok(result);
        }

        //DeleteCandidato/{id}
    }
}
