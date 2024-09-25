using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using selecciontalento_api.Services;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaEmpleoController : ControllerBase
    {
        private readonly IServicesOfertaEmpleo _servicesOfertaEmpleo;
        public OfertaEmpleoController(IServicesOfertaEmpleo servicesOfertaEmpleo)
        {
            _servicesOfertaEmpleo = servicesOfertaEmpleo;
        }
        [HttpGet]
        [Route("GetAllOfertasEmpleo")]
        public async Task<ActionResult<IEnumerable<DTOs.OfertaEmpleoDTO>>> GetAllOfertasEmpleo()
        {
            var result = await _servicesOfertaEmpleo.GetAllOfertaEmpleos();
            if (result == null)
            {
                return BadRequest($"No hay informacion registrada");
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetOfertasEmpleoById/{id}")]
        public async Task<ActionResult<DTOs.OfertaEmpleoDTO>> GetOfertasEmpleoById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Error, campo Id {id} vacio o incorrecto");
            }
            var result = await _servicesOfertaEmpleo.GetOfertaEmpleoById(id);
            if (result == null)
            {
                return NotFound($"Error, no existe informacion por el campo Id: {id}");
            }
            return Ok(result);

        }
        [HttpPost]
        [Route("SaveOfertasEmpleo")]
        public async Task<ActionResult<bool>> SaveOfertasEmpleo(DTOs.OfertaEmpleoDTO ofertaEmpleoDTO)
        {
            if (ofertaEmpleoDTO == null)
            {
                return BadRequest($"Error, campos oferta empleo vacios o incorrectos");
            }
            Models.OfertaEmpleos ofertaEmpleos = new()
            {
                OfEmpId = ofertaEmpleoDTO.OfEmpId,
                OfEmpTitulo = ofertaEmpleoDTO.OfEmpTitulo,
                OfEmpSubTitulo = ofertaEmpleoDTO.OfEmpSubTitulo,
                OfEmpDescripcion = ofertaEmpleoDTO.OfEmpDescripcion,
                OfEmpRequisitos = ofertaEmpleoDTO.OfEmpRequisitos,
                OfEmpTipoEmpleo = ofertaEmpleoDTO.OfEmpTipoEmpleo,
                OfEmpModalidad = ofertaEmpleoDTO.OfEmpModalidad,
                OfEmpSueldo = ofertaEmpleoDTO.OfEmpSueldo,
                OfEmpFechaOferta = ofertaEmpleoDTO.OfEmpFechaOferta,
                OfEmpFechaLimite = ofertaEmpleoDTO.OfEmpFechaLimite,
                ProId = ofertaEmpleoDTO.ProId,
                EmpId = ofertaEmpleoDTO.EmpId,
                EstId = ofertaEmpleoDTO.EstId,
            };
            var result = await _servicesOfertaEmpleo.SaveOfertaEmpleo(ofertaEmpleos);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest($"Error en crear una oferta de empleo");
            }
        }
        [HttpPut]
        [Route("UpdateOfertasEmpleo")]
        public async Task<ActionResult<bool>> UpdateOfertasEmpleo(DTOs.OfertaEmpleoDTO ofertaEmpleoDTO)
        {
            if (ofertaEmpleoDTO == null)
            {
                return BadRequest($"Error, campos oferta empleo vacios o incorrectos");
            }
            Models.OfertaEmpleos ofertaEmpleos = new()
            {
                OfEmpId = ofertaEmpleoDTO.OfEmpId,
                OfEmpTitulo = ofertaEmpleoDTO.OfEmpTitulo,
                OfEmpSubTitulo = ofertaEmpleoDTO.OfEmpSubTitulo,
                OfEmpDescripcion = ofertaEmpleoDTO.OfEmpDescripcion,
                OfEmpRequisitos = ofertaEmpleoDTO.OfEmpRequisitos,
                OfEmpTipoEmpleo = ofertaEmpleoDTO.OfEmpTipoEmpleo,
                OfEmpModalidad = ofertaEmpleoDTO.OfEmpModalidad,
                OfEmpSueldo = ofertaEmpleoDTO.OfEmpSueldo,
                OfEmpFechaOferta = ofertaEmpleoDTO.OfEmpFechaOferta,
                OfEmpFechaLimite = ofertaEmpleoDTO.OfEmpFechaLimite,
                ProId = ofertaEmpleoDTO.ProId,
                EmpId = ofertaEmpleoDTO.EmpId,
                EstId = ofertaEmpleoDTO.EstId,
            };
            var result = await _servicesOfertaEmpleo.UpdateOfertaEmpleo(ofertaEmpleos);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest($"Error en actualizar una oferta de empleo");
            }
        }
        [HttpDelete]
        [Route("DeleteOfertasEmpleo")]
        public async Task<ActionResult<bool>> DeleteOfertasEmpleo(DTOs.OfertaEmpleoDTO ofertaEmpleoDTO)
        {
            if (ofertaEmpleoDTO == null)
            {
                return BadRequest($"Error, campos oferta empleo vacios o incorrectos");
            }
            Models.OfertaEmpleos ofertaEmpleos = new()
            {
                OfEmpId = ofertaEmpleoDTO.OfEmpId,
                OfEmpTitulo = ofertaEmpleoDTO.OfEmpTitulo,
                OfEmpSubTitulo = ofertaEmpleoDTO.OfEmpSubTitulo,
                OfEmpDescripcion = ofertaEmpleoDTO.OfEmpDescripcion,
                OfEmpRequisitos = ofertaEmpleoDTO.OfEmpRequisitos,
                OfEmpTipoEmpleo = ofertaEmpleoDTO.OfEmpTipoEmpleo,
                OfEmpModalidad = ofertaEmpleoDTO.OfEmpModalidad,
                OfEmpSueldo = ofertaEmpleoDTO.OfEmpSueldo,
                OfEmpFechaOferta = ofertaEmpleoDTO.OfEmpFechaOferta,
                OfEmpFechaLimite = ofertaEmpleoDTO.OfEmpFechaLimite,
                ProId = ofertaEmpleoDTO.ProId,
                EmpId = ofertaEmpleoDTO.EmpId,
                EstId = ofertaEmpleoDTO.EstId,
            };
            var result = await _servicesOfertaEmpleo.DeleteOfertaEmpleo(ofertaEmpleos.EmpId);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest($"Error en eliminar una oferta de empleo");
            }
        }
    }
}
