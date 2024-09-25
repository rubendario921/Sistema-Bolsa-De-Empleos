using Microsoft.EntityFrameworkCore;
using selecciontalento_api.DTOs;
using selecciontalento_api.Models;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Services
{
    public class ServicesCantidadEmpleados : IServicesCantidadEmpleados
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public ServicesCantidadEmpleados(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }


        public async Task<IEnumerable<CantidadEmpleadosDTO>> GetAllCantidadEmpleados()
        {
            try
            {
                var result = await _dataContext.CantidadEmpleados.Select(c => new CantidadEmpleadosDTO()
                {
                    CantEmpId = c.CantEmpId,
                    CantEmpDetails = c.CantEmpDetails,
                }).ToListAsync();
                if (result.Count <= 0)
                {
                    throw new Exception($"No hay informacion registrada");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllCantidadEmpleados: {ex.Message}");
                throw;
            }
        }

        public async Task<CantidadEmpleadosDTO> GetCantidadEmpleadoById(int id)
        {
            try
            {
                var result = await _dataContext.CantidadEmpleados.Where(c => c.CantEmpId.Equals(id)).Select(c => new CantidadEmpleadosDTO { CantEmpId = c.CantEmpId, CantEmpDetails = c.CantEmpDetails }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetCantidadEmpleadoById: {ex.Message}");
                throw;
            }
        }

        public async Task<CantidadEmpleadosDTO> GetCantidadEmpleadoByName(string name)
        {
            try
            {
                var result = await _dataContext.CantidadEmpleados.Where(c => c.CantEmpDetails.Equals(name)).Select(c => new CantidadEmpleadosDTO { CantEmpId = c.CantEmpId, CantEmpDetails = c.CantEmpDetails }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetCantidadEmpleadoByName: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> SaveCantidadEmpleados(CantidadEmpleados cantidadEmpleado)
        {
            try
            {
                var dataCantidadEmpeleados = await GetCantidadEmpleadoByName(cantidadEmpleado.CantEmpDetails);
                if (dataCantidadEmpeleados != null)
                {
                    throw new Exception($"Error, registro duplicado");
                }
                _dataContext.CantidadEmpleados.Add(cantidadEmpleado);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SaveCantidadEmpleados: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateCantidadEmpleados(CantidadEmpleados cantidadEmpleado)
        {
            try
            {
                var dataCantidadEmpleados = await GetCantidadEmpleadoById(cantidadEmpleado.CantEmpId);
                if (dataCantidadEmpleados == null)
                {
                    throw new Exception($"Error, no existe informacion con el ID: {cantidadEmpleado.CantEmpId}");
                }
                _dataContext.Entry(cantidadEmpleado).State = EntityState.Modified;
                return await _dataContext.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateCantidadEmpleados: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeleteCantidadEmpleados(int id)
        {
            try
            {
                var data = await GetCantidadEmpleadoById(id);
                if (data == null)
                {
                    throw new Exception($"Error, no existe informacion por el ID: {id}");
                }
                Models.CantidadEmpleados cantidadEmpleados = new() { CantEmpId = data.CantEmpId, CantEmpDetails = data.CantEmpDetails };
                _dataContext.CantidadEmpleados.Remove(cantidadEmpleados);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteCantidadEmpleados: {ex.Message}");
                throw;
            }
        }
    }
}
