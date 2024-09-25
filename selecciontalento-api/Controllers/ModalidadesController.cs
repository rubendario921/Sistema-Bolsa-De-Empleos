using Microsoft.AspNetCore.Mvc;
using selecciontalento_api.Services;

namespace selecciontalento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadesController : ControllerBase
    {
        private readonly IServicesModalidades _servicesModalidades;
        public ModalidadesController(IServicesModalidades servicesModalidades)
        {
            _servicesModalidades = servicesModalidades;
        }

        [HttpGet]
        [Route("GetAllModalidades")]
        public async Task<ActionResult<IEnumerable<DTOs.ModalidadesDTO>>> GetAllModalidades()
        {
            var modalidades = await _servicesModalidades.GetAllModalidades();
            if (modalidades == null)
            {
                return NotFound("No se encotraron datos registrados.");
            }
            return Ok(modalidades);
        }

        [HttpGet]
        [Route("GetModalidadById/{id}")]
        public async Task<ActionResult<DTOs.ModalidadesDTO>> GetModalidadById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Error, campo Id: {id} incorrecto o vacio.");
            }
            var modalidades = await _servicesModalidades.GetModalidadById(id);
            if (modalidades == null)
            {
                return NotFound($"No existe informacion con Id: {id}.");
            }
            return Ok(modalidades);
        }

        [HttpPost]
        [Route("SaveModalidad")]
        public async Task<ActionResult<bool>> SaveModalidad(DTOs.ModalidadesDTO modalidadesDTO)
        {
            if (modalidadesDTO == null)
            {
                return BadRequest($"Error, campo ModalidadDTO {modalidadesDTO} incorrecto o vacio");
            }
            //Transformar de DTO a Models
            Models.Modalidades modalidad = new Models.Modalidades() { ModName = modalidadesDTO.ModName, ModInformacion = modalidadesDTO.ModInformacion };

            var result = await _servicesModalidades.SaveModalidad(modalidad);
            if (result!)
            {
                BadRequest($"Error, Modalidad ya registrada, ingrese los datos correctamente.");
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateModalidad/{id}")]
        public async Task<ActionResult<bool>> UpdateModalidad(int id, DTOs.ModalidadesDTO modalidadesDTO)
        {
            if (id <= 0)
            {
                return BadRequest($"Campo ID: {id} incorrecto o vacio.");
            }
            if (modalidadesDTO == null)
            {
                return BadRequest($"Error, modalidadDTO {modalidadesDTO} incorrecto o vacio.");
            }
            ////Transformar de DTO a Models
            Models.Modalidades modalidad = new()
            {
                ModId = id,
                ModName = modalidadesDTO.ModName,
                ModInformacion = modalidadesDTO.ModInformacion,
            };
            var result = await _servicesModalidades.SaveModalidad(modalidad);
            if (result!)
            {
                return BadRequest($"Error al actualizar la modalidad, ingrese los datos correctamente.");
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeteleModalidad/{id}")]
        public async Task<ActionResult<bool>> DeleteModalidad(int id)
        {
            if (id <= 0) { return BadRequest($"Campo Id: {id} incorrecto o vacio."); }
            var result = await _servicesModalidades.DeleteModalidad(id);
            if (result!)
            {
                return BadRequest($"Error al elminiar la modalidad, intente nuevamente");
            }
            return Ok(result);
        }
    }
}