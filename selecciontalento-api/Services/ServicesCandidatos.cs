using Microsoft.EntityFrameworkCore;
using selecciontalento_api.DTOs;
using selecciontalento_api.Models;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Services
{
    public class ServicesCandidatos : IServicesCandidatos
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;
        public ServicesCandidatos(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<CandidatosDTO>> GetAllCandidatos()
        {
            try
            {
                var result = await _dataContext.Candidatos.Select(c => new DTOs.CandidatosDTO { CanId = c.CanId, CanNombre = c.CanNombre, CanApellido = c.CanApellido, CanNacionalidad = c.CanNacionalidad, FechaNacimiento = c.FechaNacimiento, CanEstadoCivil = c.CanEstadoCivil, CanTipoDni = c.CanTipoDni, CanNumDni = c.CanNumDni, CanPassword = c.CanPassword, CanGenero = c.CanGenero }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllCandidatos: {ex.Message}");
                throw;
            }
        }

        public async Task<CandidatosDTO> GetCandidatoById(int id)
        {
            try
            {
                var result = await _dataContext.Candidatos.Where(c => c.CanId.Equals(id)).Select(c => new DTOs.CandidatosDTO { CanId = c.CanId, CanNombre = c.CanNombre, CanApellido = c.CanApellido, CanNacionalidad = c.CanNacionalidad, FechaNacimiento = c.FechaNacimiento, CanEstadoCivil = c.CanEstadoCivil, CanTipoDni = c.CanTipoDni, CanNumDni = c.CanNumDni, CanPassword = c.CanPassword, CanGenero = c.CanGenero }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetCandidatoById: {ex.Message}");
                throw;
            }
        }

        public async Task<CandidatosDTO> GetCandidatoByNumDni(string numDni)
        {
            try
            {
                var result = await _dataContext.Candidatos.Where(c => c.CanNumDni.Equals(numDni)).Select(c => new DTOs.CandidatosDTO { CanId = c.CanId, CanNombre = c.CanNombre, CanApellido = c.CanApellido, CanNacionalidad = c.CanNacionalidad, FechaNacimiento = c.FechaNacimiento, CanEstadoCivil = c.CanEstadoCivil, CanTipoDni = c.CanTipoDni, CanNumDni = c.CanNumDni, CanPassword = c.CanPassword, CanGenero = c.CanGenero }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetCandidatoByNumDni: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> SaveCandidato(Candidatos candidatos)
        {
            try
            {
                var result = await GetCandidatoByNumDni(candidatos.CanNumDni);
                if (result != null)
                {
                    throw new Exception($"Registro duplicado, intente nuevamente");
                }
                _dataContext.Candidatos.Add(candidatos);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SaveCandidato: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateCandidato(Candidatos candidatos)
        {
            try
            {
                var result = await GetCandidatoById(candidatos.CanId) ?? throw new Exception($"No existe registro por el ID: {candidatos.CanId}");
                _dataContext.Entry(candidatos).State = EntityState.Modified;
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateCandidato: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeleteCandidato(Candidatos candidatos)
        {
            try
            {
                var result = await GetCandidatoById(candidatos.CanId) ?? throw new Exception($"No existe registro por el ID: {candidatos.CanId}");
                _dataContext.Remove(candidatos);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteCandidato: {ex.Message}");
                throw;
            }
        }
    }
}
