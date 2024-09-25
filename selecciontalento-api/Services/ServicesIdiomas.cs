using Microsoft.EntityFrameworkCore;
using selecciontalento_api.DTOs;
using selecciontalento_api.Models;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Services
{
    public class ServicesIdiomas : IServicesIdiomas
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public ServicesIdiomas(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<IEnumerable<IdiomasDTO>> GetAllIdiomas()
        {
            try
            {
                var result = await _dataContext.Idiomas.Select(i => new IdiomasDTO { IdiomaId = i.IdiId, IdiName = i.IdiName }).ToListAsync();
                if (result.Count != 0)
                {
                    return result;
                }
                else
                {
                    throw new Exception("No hay informacion de idiomas registrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllIdiomas: {ex.Message}");
                throw;
            }
        }

        public async Task<IdiomasDTO> GetIdiomaById(int id)
        {
            try
            {
                var result = await _dataContext.Idiomas.Where(r => r.IdiId.Equals(id)).Select(i => new IdiomasDTO { IdiomaId = i.IdiId, IdiName = i.IdiName }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetIdiomaById: {ex.Message}");
                throw;
            }
        }

        public async Task<IdiomasDTO> GetIdiomaByName(string name)
        {
            try
            {
                var result = await _dataContext.Idiomas.Where(i => i.IdiName.Equals(name)).Select(i => new IdiomasDTO { IdiomaId = i.IdiId, IdiName = i.IdiName }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex) { Console.WriteLine($"Error en GetIdiomaByName: {ex.Message}"); throw; }
        }

        public async Task<bool> SaveIdioma(Idiomas idiomas)
        {
            try
            {
                var dataIdiomas = await GetIdiomaByName(idiomas.IdiName);
                if (dataIdiomas != null)
                {
                    throw new Exception($"Idioma ya registrado, revise la información.");
                }
                _dataContext.Idiomas.Add(idiomas);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex) { Console.WriteLine($"Error en SaveIdiomas: {ex.Message}"); throw; }
        }

        public async Task<bool> UpdateIdioma(Idiomas idiomas)
        {
            try
            {
                var dataIdioma = await GetIdiomaById(idiomas.IdiId);
                if (dataIdioma != null)
                {
                    _dataContext.Entry(idiomas).State = EntityState.Modified;
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception("Error en actualizar el idioma");
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error en UpdateIdioma: {ex.Message}"); throw; }
        }
        public async Task<bool> DeleteIdioma(int id)
        {
            try
            {
                var dataIdioma = await GetIdiomaById(id);
                if (dataIdioma != null)
                {
                    Models.Idiomas idioma = new() { IdiId = dataIdioma.IdiomaId, IdiName = dataIdioma.IdiName };
                    _dataContext.Idiomas.Remove(idioma);
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception($"Error en eliminar el idioma");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteIdioma: {ex.Message}");
                throw;
            }
        }
    }
}
