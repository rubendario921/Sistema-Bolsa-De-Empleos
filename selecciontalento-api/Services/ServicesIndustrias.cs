using Microsoft.EntityFrameworkCore;
using selecciontalento_api.DTOs;
using selecciontalento_api.Models;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Services
{
    public class ServicesIndustrias : IServicesIndustrias
    {

        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        //Constructor
        public ServicesIndustrias(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }


        public async Task<IEnumerable<IndustriasDTO>> GetAllIndustrias()
        {
            try
            {
                var result = await _dataContext.Industrias.Select(r => new IndustriasDTO {
                    IndId = r.IndId,
                    IndName = r.IndName,
                    IndDetails = r.IndDetails,
                }).ToListAsync();
                if (result.Count == 0) {
                    throw new Exception($"No hay informacion de Industrias registradas");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllIndustrias: {ex.Message}");
                throw;
            }
        }

        public async Task<IndustriasDTO> GetIndustriaById(int id)
        {
            try
            {
                var result = await _dataContext.Industrias.Where(x =>x.IndId.Equals(id)).Select(x=>new IndustriasDTO { IndId = x.IndId,
                    IndName = x.IndName, IndDetails = x.IndDetails}).FirstOrDefaultAsync();
                return result!; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetIndustriaById: {ex.Message}");
                throw;
            }
        }

        public async Task<IndustriasDTO> GetIndustriaByName(string name)
        {
            try
            {
                var result = await _dataContext.Industrias.Where(x => x.IndName.Equals(name)).Select(x => new IndustriasDTO
                {
                    IndId = x.IndId,
                    IndName = x.IndName,
                    IndDetails = x.IndDetails
                }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetIndustriaById: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> SaveIndustria(Industrias industria)
        {
            try
            {
                var dataIndustria = await GetIndustriaByName(industria.IndName);
                if (dataIndustria != null) {
                    throw new Exception($"Error, Registro Duplicado.");
                }
                _dataContext.Industrias.Add( industria );
                return await _dataContext.SaveChangesAsync()>0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SaveRol: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateIndustria(Industrias industria)
        {
            try
            {
                var dataIndustria = await GetIndustriaById(industria.IndId);
                if (dataIndustria == null)
                {
                    throw new Exception($"Error, No existe informacion por el ID: {industria.IndId}.");
                }
                _dataContext.Entry(industria).State = EntityState.Modified;
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateIndustria: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeleteIndustria(int id)
        {
            try
            {
                var dataIndustria = await GetIndustriaById(id);
                if (dataIndustria == null) {
                    throw new Exception($"Error, No existe informacion por el ID: {id}.");
                }
                Models.Industrias industria = new() { IndId = dataIndustria.IndId, IndName = dataIndustria.IndName, IndDetails = dataIndustria.IndDetails };
                _dataContext.Industrias.Remove(industria);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteIndustria: {ex.Message}");
                throw;
            }
        }
    }
}
