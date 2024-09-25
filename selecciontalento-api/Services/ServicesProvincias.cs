using Microsoft.EntityFrameworkCore;
using selecciontalento_api.Models;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Services
{
    public class ServicesProvincias : IServicesProvincias
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public ServicesProvincias(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Provincias>> GetAllProvincias()
        {
            try
            {
                var result = await _dataContext.Provincias.ToListAsync();
                if (result.Count <= 0)
                {
                    throw new Exception($"No existes informacion registrada");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllProvincias:{ex.Message}");
                throw;
            }
        }

        public async Task<Provincias> GetProvinciaById(int id)
        {
            try
            {
                var result = await _dataContext.Provincias.Where(p => p.ProId.Equals(id)).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetProvinciaById:{ex.Message}");
                throw;
            }
        }

        public async Task<bool> SaveProvincia(Provincias provincia)
        {
            try
            {
                var result = await GetProvinciaById(provincia.ProId);
                if (result != null)
                {
                    throw new Exception("Datos duplicado, intente nuevamente");
                }
                _dataContext.Provincias.Add(provincia);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SaveProvincia {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateProvincia(Provincias provincia)
        {
            try
            {
                var result = await GetProvinciaById(provincia.ProId);
                if (result == null)
                {
                    throw new Exception("Datos duplicado, intente nuevamente");
                }
                _dataContext.Entry(provincia).State = EntityState.Modified;
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateProvincia {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeleteProvincia(int id)
        {
            try
            {
                var result = await GetProvinciaById(id);
                if (result == null)
                {
                    throw new Exception($"Error, no existe informacion por Id:{id}");
                }
                Models.Provincias provincia = new() { ProId = result.ProId, ProdName = result.ProdName, ProdCapital = result.ProdCapital };
                _dataContext.Provincias.Remove(provincia);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteProvincia {ex.Message}");
                throw;
            }

        }

        public async Task<Provincias> GetProvinciaByName(string name)
        {
            try
            {
                var result = await _dataContext.Provincias.Where(p => p.ProdName.Equals(name)).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetProvinciaById:{ex.Message}");
                throw;
            }
        }
    }
}
