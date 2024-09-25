using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using selecciontalento_api.DTOs;
using selecciontalento_api.Models;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Services
{
    public class ServicesEstados : IServiceEstados
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;

        //Constructor
        public ServicesEstados(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<IEnumerable<EstadosDTO.EstadosResponse>> GetAllEstados()
        {
            try
            {
                var result = await _dataContext.Estados.Select(e => new EstadosDTO.EstadosResponse { EstId = e.EstId, EstName = e.EstName, EstCategory = e.EstCategory, EstColor = e.EstColor }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllEstados: {ex.Message}");
                throw;
            }
        }
        public async Task<EstadosDTO.EstadosResponse> GetEstadosById(int id)
        {
            try
            {
                var result = await _dataContext.Estados.Where(e => e.EstId.Equals(id)).Select(e => new EstadosDTO.EstadosResponse
                {
                    EstId = e.EstId,
                    EstName = e.EstName,
                    EstCategory = e.EstCategory!,
                    EstColor = e.EstColor!,
                }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetEstadosById{ex.Message}");
                throw;
            }
        }
        public async Task<EstadosDTO.EstadosResponse> GetEstadosByName(string? name)
        {
            try
            {
                var result = await _dataContext.Estados.Where(dataEstado => dataEstado.EstName.Equals(name)).Select(e => new EstadosDTO.EstadosResponse { EstId = e.EstId, EstName = e.EstName, EstCategory = e.EstCategory, EstColor = e.EstColor }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetEstadosByName : {ex.Message}");
                throw;
            }
        }

        public async Task<EstadosDTO.EstadosResponse> GetEstadosByCategory(string? category)
        {
            try
            {
                var result = await _dataContext.Estados.Where(dataEstado => dataEstado.EstCategory.Equals(category)).Select(e => new EstadosDTO.EstadosResponse { EstId = e.EstId, EstName = e.EstName, EstCategory = e.EstCategory, EstColor = e.EstColor }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetEstadosById{ex.Message}");
                throw;
            }
        }

        public async Task<bool> SaveEstados(Models.Estados estados)
        {
            try
            {
                //Validacion de datos ingresados por nombre
                var dataNameEstado = await GetEstadosByName(estados.EstName);
                if (dataNameEstado == null)
                {
                    _dataContext.Estados.Add(estados);
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception($"Registro Duplicado, intente nuevamente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SaveEstados: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateEstados(Models.Estados estados)
        {
            try
            {
                //Obtener informacion del estado por ID
                var result = await GetEstadosById(estados.EstId);
                if (result != null)
                {
                    _dataContext.Entry(estados).State = EntityState.Modified;
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception($"No existe informacion por ID: {estados.EstId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateEstados: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeleteEsteados(int id)
        {
            try
            {
                //Obtener informacion de estado por ID
                var dataEstado = await GetEstadosById(id);
                if (dataEstado != null)
                {
                    Models.Estados estado = new Estados() { EstId = dataEstado.EstId, EstName = dataEstado.EstName, EstCategory = dataEstado.EstCategory, EstColor = dataEstado.EstColor };
                    _dataContext.Remove(estado);
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception($"No existe informacion de por ID:{id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteEstados{ex.Message}");
                throw;
            }
        }
    }
}
