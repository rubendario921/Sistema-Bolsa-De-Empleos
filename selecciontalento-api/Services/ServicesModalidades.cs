using Microsoft.EntityFrameworkCore;
using selecciontalento_api.DTOs;
using selecciontalento_api.Models;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Services
{
    public class ServicesModalidades : IServicesModalidades
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public ServicesModalidades(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<ModalidadesDTO>> GetAllModalidades()
        {
            try
            {
                var result = await _dataContext.Modalidades.Select(m => new DTOs.ModalidadesDTO
                {
                    ModId = m.ModId,
                    ModName = m.ModName,
                    ModInformacion = m.ModInformacion,
                }).ToListAsync()?? throw new Exception($"No hay informacion registrada.");                
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllModalidades :{ex.Message}");
                throw;
            }
        }

        public async Task<ModalidadesDTO> GetModalidadById(int id)
        {
            try
            {
                var result = await _dataContext.Modalidades.Where(m => m.ModId.Equals(id)).Select(m => new ModalidadesDTO { ModId = m.ModId, ModName = m.ModName, ModInformacion = m.ModInformacion }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex) { Console.WriteLine($"Error en GetModalidadById: {ex.Message}"); throw; }
        }

        public async Task<ModalidadesDTO> GetModalidadByName(string name)
        {
            try
            {
                var result = await _dataContext.Modalidades.Where(m => m.ModName.Equals(name)).Select(m => new ModalidadesDTO { ModId = m.ModId, ModName = m.ModName, ModInformacion = m.ModInformacion }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex) { Console.WriteLine($"Error en GetModalidadById: {ex.Message}"); throw; }
        }

        public async Task<bool> SaveModalidad(Modalidades modalidad)
        {
            try
            {
                var result = await GetModalidadByName(modalidad.ModName);
                if (result != null) {
                    throw new Exception("Error, registro duplicado");
                }
                _dataContext.Modalidades.Add(modalidad);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex) { Console.WriteLine($"Error en SaveModalidad: {ex.Message}"); throw; }
        }

        public async Task<bool> UpdateModalidad(Modalidades modalidad)
        {
            try
            {
                var result = await GetModalidadById(modalidad.ModId) ?? throw new Exception($"No existe informacion por ID: {modalidad.ModId}");

                _dataContext.Entry(modalidad).State = EntityState.Modified;
                return await _dataContext.SaveChangesAsync() > 0;

            }
            catch (Exception ex) { Console.WriteLine($"Error en UpdateModalidad: {ex.Message}"); throw; }
        }
        public async Task<bool> DeleteModalidad(int id)
        {
            try
            {
                var result = await GetModalidadById(id) ?? throw new Exception($"No existe informacion por ID: {id}");

                Modalidades modalidad = new() { ModId = result.ModId, ModName = result.ModName, ModInformacion = result.ModInformacion };

                _dataContext.Modalidades.Remove(modalidad);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteModalidad: {ex.Message}");
                throw;
            }
        }
    }
}
