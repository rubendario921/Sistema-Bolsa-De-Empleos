using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using selecciontalento_api.DTOs;
using selecciontalento_api.Models;
using selecciontalento_api.Services;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CantidadEmpleadosController : ControllerBase
    {
        private readonly IServicesCantidadEmpleados _servicesCantidadEmpleados;

        public CantidadEmpleadosController(IServicesCantidadEmpleados servicesCantidadEmpleados)
        {
            _servicesCantidadEmpleados = servicesCantidadEmpleados;
        }

        [HttpGet]
        [Route("GetAllCantidadEmpleados")]
        public async Task<ActionResult<IEnumerable<DTOs.CantidadEmpleadosDTO>>> GetAllRoles()
        {
            var result = await _servicesCantidadEmpleados.GetAllCantidadEmpleados();
            if (result == null)
            {
                return NotFound("No hay información registrada");
            }
            return Ok(result);
        }


        [HttpGet]
        [Route("GetCantidadEmpleadoById/{id}")]
        public async Task<ActionResult<DTOs.CantidadEmpleadosDTO>> GetCantidadEmpleadoById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Campo Id: {id} vacio o incorrecto");
            }
            var result = await _servicesCantidadEmpleados.GetCantidadEmpleadoById(id);
            if (result == null)
            {
                return NotFound($"No existe informacion registrada por Id: {id}");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveCantidadEmpleado")]
        public async Task<ActionResult<bool>> SaveCantidadEmpleado(DTOs.CantidadEmpleadosDTO cantidadEmpleadosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error, campos vacios o incorrectos");
            }
            Models.CantidadEmpleados cantidadEmpleados = new() { CantEmpId = cantidadEmpleadosDTO.CantEmpId, CantEmpDetails = cantidadEmpleadosDTO.CantEmpDetails };
            var result = await _servicesCantidadEmpleados.SaveCantidadEmpleados(cantidadEmpleados);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error, en guardar el registro");
            }

        }

        [HttpPut]
        [Route("UpdateCantidadEmpleado/{id}")]
        public async Task<ActionResult<bool>> UpdateCantidadEmpleado(int id, DTOs.CantidadEmpleadosDTO cantidadEmpleadosDTO)
        {
            if (id <= 0)
            {
                return BadRequest($"Campo ID: {id} vacio o incorrecto");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Error, campos vacios o incorrectos");
            }
            Models.CantidadEmpleados cantidadEmpleados = new() { CantEmpId = cantidadEmpleadosDTO.CantEmpId, CantEmpDetails = cantidadEmpleadosDTO.CantEmpDetails };
            var result = await _servicesCantidadEmpleados.UpdateCantidadEmpleados(cantidadEmpleados);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error, en guardar el registro");
            }
        }

        [HttpDelete]
        [Route("DeleteCantidadEmpleado/{id}")]
        public async Task<ActionResult<bool>> DeleteCantidadEmpleado(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Campo ID: {id} vacio o incorrecto");
            }
            var result = await _servicesCantidadEmpleados.DeleteCantidadEmpleados(id);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error, en guardar el registro");
            }
        }
    }
}
