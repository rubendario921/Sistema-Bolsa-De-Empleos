using Microsoft.AspNetCore.Mvc;
using selecciontalento_api.DTOs;
using selecciontalento_api.Services;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController(IServiceEstados serviceEstados) : ControllerBase
    {
        //Contextos de servicios
        private readonly IServiceEstados _serviceEstados = serviceEstados;

        [HttpGet]
        [Route("GetAllEstados")]
        public async Task<ActionResult<IEnumerable<EstadosDTO.EstadosResponse>>> GetAllEstados()
        {
            var estados = await _serviceEstados.GetAllEstados();
            if (estados != null)
            {
                return Ok(estados);
            }
            else
            {
                return NotFound("No se encontraron estados");
            }
        }

        [HttpGet]
        [Route("GetEstadosById/{id}")]
        public async Task<ActionResult<EstadosDTO.EstadosResponse>> GetEstadosById(int id)
        {
            if (id > 0)
            {
                var estado = await _serviceEstados.GetEstadosById(id);
                if (estado != null)
                {
                    return Ok(estado);
                }
                else
                {
                    return NotFound($"No existe estado con el: {id}.");
                }
            }
            else
            {
                return NotFound($"Campo ID {id} incorrecto o vacio.");
            }
        }

        [HttpPost]
        [Route("SaveEstado")]
        public async Task<ActionResult<bool>> SaveEstado(EstadosDTO.EstadoRequest estadosRequest)
        {
            if (estadosRequest != null)
            {
                Models.Estados estadosData = new()
                {
                    EstName = estadosRequest.EstName,
                    EstCategory = estadosRequest.EstCategory,
                    EstColor = estadosRequest.EstColor,
                };
                var result = await _serviceEstados.SaveEstados(estadosData);
                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound($"Estados ya existe, ingrese los datos correctamente.");
                }
            }
            else
            {
                return NotFound("Datos vacios, verifique lo información.");
            }
        }

        [HttpPut]
        [Route("UpdateEstado/{id}")]
        public async Task<ActionResult<bool>> UpdateEstado(int id, EstadosDTO.EstadoRequest estadosRequest)
        {
            if (id <= 0)
            {
                return BadRequest($"Campo ID: {id} vacio o incorrecto.");
            }
            if (estadosRequest == null)
            {
                return BadRequest($"Campo de estado vacios o incorrectos.");
            }
            Models.Estados estado = new()
            {
                EstId = id,
                EstName = estadosRequest.EstName,
                EstCategory = estadosRequest.EstCategory,
                EstColor = estadosRequest.EstColor,
            };
            var result = await _serviceEstados.UpdateEstados(estado);
            if (!result)
            {
                return NotFound($"Error al actualizar el estado, ingrese los datos correctamente.");
            }
            return Ok(true);
        }

        [HttpDelete]
        [Route("DeleteEstado/{id}")]
        public async Task<ActionResult<bool>> DeleteEstado(int id)
        {
            if (id > 0)
            {
                var result = await _serviceEstados.DeleteEsteados(id);
                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound("Error al eliminar el estados, intente nuevamente.");
                }
            }
            else
            {
                return NotFound($"No existe el id: {id} ingresado");
            }
        }
    }
}