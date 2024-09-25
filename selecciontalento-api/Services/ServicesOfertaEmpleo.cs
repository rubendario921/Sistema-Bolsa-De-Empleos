using Microsoft.EntityFrameworkCore;
using selecciontalento_api.DTOs;
using selecciontalento_api.Models;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Services
{
    public class ServicesOfertaEmpleo : IServicesOfertaEmpleo
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public ServicesOfertaEmpleo(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<IEnumerable<OfertaEmpleoDTO>> GetAllOfertaEmpleos()
        {
            try
            {
                var result = await _dataContext.OfertaEmpleos.Include(e => e.Estado).Include(e => e.Empresa).Include(e => e.Provincia).Select(o => new OfertaEmpleoDTO { OfEmpId = o.OfEmpId,
                    OfEmpTitulo = o.OfEmpTitulo,
                    OfEmpSubTitulo = o.OfEmpSubTitulo,
                    OfEmpDescripcion = o.OfEmpDescripcion,
                    OfEmpRequisitos = o.OfEmpRequisitos,
                    OfEmpTipoEmpleo = o.OfEmpTipoEmpleo,
                    OfEmpModalidad = o.OfEmpModalidad,
                    OfEmpSueldo = o.OfEmpSueldo,
                    OfEmpFechaOferta = o.OfEmpFechaOferta,
                    OfEmpFechaLimite = o.OfEmpFechaLimite,
                    EstId = o.Estado.EstId,
                    EstNombre = o.Estado.EstName,
                    EstColor = o.Estado.EstColor,
                    EmpId = o.Empresa.EmpId,
                    EmpName = o.Empresa.EmpName,
                    ProId = o.Provincia.ProId,
                    ProName = o.Provincia.ProdName,
                    ProCapital = o.Provincia.ProdCapital
                }).ToListAsync();
                if (result.Count <= 0)
                {
                    throw new Exception("No hay información de Roles registrados.");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllOfertaEmpleos:{ex.Message}");
                throw;
            }
        }

        public async Task<OfertaEmpleoDTO> GetOfertaEmpleoById(int id)
        {
            try
            {
                var result = await _dataContext.OfertaEmpleos.Where(q => q.OfEmpId.Equals(id)).Include(e => e.Estado).Include(e => e.Empresa).Include(e => e.Provincia).Select(o => new OfertaEmpleoDTO { OfEmpId = o.OfEmpId,
                    OfEmpTitulo = o.OfEmpTitulo,
                    OfEmpSubTitulo = o.OfEmpSubTitulo,
                    OfEmpDescripcion = o.OfEmpDescripcion,
                    OfEmpRequisitos = o.OfEmpRequisitos,
                    OfEmpTipoEmpleo = o.OfEmpTipoEmpleo,
                    OfEmpModalidad = o.OfEmpModalidad,
                    OfEmpSueldo = o.OfEmpSueldo,
                    OfEmpFechaOferta = o.OfEmpFechaOferta,
                    OfEmpFechaLimite = o.OfEmpFechaLimite,
                    EstId = o.Estado.EstId,
                    EstNombre = o.Estado.EstName,
                    EstColor = o.Estado.EstColor,
                    EmpId = o.Empresa.EmpId,
                    EmpName = o.Empresa.EmpName,
                    ProId = o.Provincia.ProId,
                    ProName = o.Provincia.ProdName,
                    ProCapital = o.Provincia.ProdCapital
                }).FirstOrDefaultAsync();
                return result!;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetOfertaEmpleoById:{ex.Message}");
                throw;
            }
        }

        public async Task<OfertaEmpleoDTO> GetOfertaEmpleoByTitutlo(string? name)
        {
            try
            {
                var result = await _dataContext.OfertaEmpleos.Where(q => q.OfEmpTitulo.Equals(name)).Include(e => e.Estado).Include(e => e.Empresa).Include(e => e.Provincia).Select(o => new OfertaEmpleoDTO { OfEmpId = o.OfEmpId, OfEmpTitulo = o.OfEmpTitulo, OfEmpSubTitulo = o.OfEmpSubTitulo, OfEmpDescripcion = o.OfEmpDescripcion, OfEmpTipoEmpleo = o.OfEmpTipoEmpleo, OfEmpSueldo = o.OfEmpSueldo, OfEmpFechaOferta = o.OfEmpFechaOferta, OfEmpFechaLimite = o.OfEmpFechaLimite, EstId = o.Estado.EstId, EstNombre = o.Estado.EstName, EstColor = o.Estado.EstColor, EmpId = o.Empresa.EmpId, EmpName = o.Empresa.EmpName, ProId = o.Provincia.ProId, ProName = o.Provincia.ProdName, ProCapital = o.Provincia.ProdCapital, OfEmpModalidad = o.OfEmpModalidad, OfEmpRequisitos = o.OfEmpRequisitos }).FirstOrDefaultAsync();
                return result!;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetOfertaEmpleoByTitutlo:{ex.Message}");
                throw;
            }
        }

        public async Task<bool> SaveOfertaEmpleo(OfertaEmpleos ofertaEmpleos)
        {
            try
            {
                _dataContext.OfertaEmpleos.Add(ofertaEmpleos);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SaveOfertaEmpleo:{ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateOfertaEmpleo(OfertaEmpleos ofertaEmpleos)
        {
            try
            {
                var result = await GetOfertaEmpleoById(ofertaEmpleos.OfEmpId) ?? throw new Exception($"Error, no existen datos por el ID: {ofertaEmpleos.OfEmpId}");
                _dataContext.Entry(ofertaEmpleos).State = EntityState.Modified;
                return await _dataContext.SaveChangesAsync() > 0;                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SaveOfertaEmpleo:{ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeleteOfertaEmpleo(int id)
        {
            var result = await GetOfertaEmpleoById(id) ?? throw new Exception($"Error, no existe informacion por el ID {id}");
            Models.OfertaEmpleos ofertaEmpleos = new() { OfEmpId = result.OfEmpId,
                OfEmpTitulo = result.OfEmpTitulo,
                OfEmpSubTitulo = result.OfEmpSubTitulo,
                OfEmpDescripcion = result.OfEmpDescripcion,
                OfEmpRequisitos = result.OfEmpRequisitos,
                OfEmpTipoEmpleo = result.OfEmpTipoEmpleo,
                OfEmpModalidad= result.OfEmpModalidad,
                OfEmpSueldo = result.OfEmpSueldo,
                OfEmpFechaOferta = result.OfEmpFechaOferta,
                OfEmpFechaLimite = result.OfEmpFechaLimite,
                ProId = result.ProId,
                EmpId = result.EmpId,
                EstId = 2,
            };
            _dataContext.Entry(ofertaEmpleos).State = EntityState.Modified;
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
