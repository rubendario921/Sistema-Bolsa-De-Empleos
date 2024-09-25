using Microsoft.EntityFrameworkCore;
using selecciontalento_api.DTOs;
using selecciontalento_api.Models;
using selecciontalento_api.Repositories;

namespace selecciontalento_api.Services
{
    public class ServicesEmpresas : IServicesEmpresas
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public ServicesEmpresas(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<IEnumerable<EmpresasDTO>> GetAllEmpresas()
        {
            try
            {
                var result = await _dataContext.Empresas.Include(e => e.Estado).Include(e => e.Industria).Include(e => e.CantidadEmpleado).Select(e => new DTOs.EmpresasDTO { EmpId = e.EmpId, EmpStaffName = e.EmpStaffName, EmpStaffLastName = e.EmpStaffLastName, EmpStaffEmail = e.EmpStaffEmail, EmpStaffPassword = e.EmpStaffPassword, EmpName = e.EmpName, EmpRazonSocial = e.EmpRazonSocial, EmpNumRuc = e.EmpNumRuc, EmpDireccion = e.EmpDireccion, EmpCodPostal = e.EmpCodPostal, EmpNumPhone = e.EmpNumPhone, EmpProfilePicture = e.EmpProfilePicture, EstId = e.EstId, EstName = e.Estado.EstName, EstColor = e.Estado.EstColor, IndId = e.IndId, IndName = e.Industria.IndName, CantEmpID=e.CantEmpId, CantEmpDetails = e.CantidadEmpleado.CantEmpDetails  }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllEmpresas: {ex.Message}");
                throw;
            }
        }

        public async Task<EmpresasDTO> GetEmpresaById(int id)
        {
            try
            {
                var result = await _dataContext.Empresas.Where(e => e.EmpId.Equals(id)).Include(e => e.Estado).Include(e => e.Industria).Include(e=>e.CantidadEmpleado).Select(e => new DTOs.EmpresasDTO { EmpId = e.EmpId, EmpStaffName = e.EmpStaffName, EmpStaffLastName = e.EmpStaffLastName, EmpStaffEmail = e.EmpStaffEmail, EmpStaffPassword = e.EmpStaffPassword, EmpName = e.EmpName, EmpRazonSocial = e.EmpRazonSocial, EmpNumRuc = e.EmpNumRuc, EmpDireccion = e.EmpDireccion, EmpCodPostal = e.EmpCodPostal, EmpNumPhone = e.EmpNumPhone, EmpProfilePicture = e.EmpProfilePicture, EstId = e.EstId, EstName = e.Estado.EstName, EstColor = e.Estado.EstColor, IndId = e.IndId, IndName = e.Industria.IndName, CantEmpID = e.CantEmpId, CantEmpDetails = e.CantidadEmpleado.CantEmpDetails }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetEmpresaById: {ex.Message}");
                throw;
            }
        }

        public async Task<EmpresasDTO> GetEmpresaByNumRuc(string EmpNumRuc)
        {
            try
            {
                var result = await _dataContext.Empresas.Where(e => e.EmpNumRuc.Equals(EmpNumRuc)).Include(e => e.Estado).Include(e => e.Industria).Include(e=> e.CantidadEmpleado).Select(e => new DTOs.EmpresasDTO { EmpId = e.EmpId, EmpStaffName = e.EmpStaffName, EmpStaffLastName = e.EmpStaffLastName, EmpStaffEmail = e.EmpStaffEmail, EmpStaffPassword = e.EmpStaffPassword, EmpName = e.EmpName, EmpRazonSocial = e.EmpRazonSocial, EmpNumRuc = e.EmpNumRuc, EmpDireccion = e.EmpDireccion, EmpCodPostal = e.EmpCodPostal, EmpNumPhone = e.EmpNumPhone, EmpProfilePicture = e.EmpProfilePicture, EstId = e.EstId, EstName = e.Estado.EstName, EstColor = e.Estado.EstColor, IndId = e.IndId, IndName = e.Industria.IndName, CantEmpID = e.CantEmpId, CantEmpDetails = e.CantidadEmpleado.CantEmpDetails }).FirstOrDefaultAsync();
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetEmpresaByNumRuc: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> SaveEmpresa(Empresas empresa)
        {
            try
            {
                var dataEmpresa = await GetEmpresaByNumRuc(empresa.EmpNumRuc);
                if (dataEmpresa != null)
                {
                    throw new Exception($"Registro Duplicado, revise los datos e ingrese nuevamente.");
                }
                else
                {
                    _dataContext.Empresas.Add(empresa);
                    return await _dataContext.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SaveEmpresa: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateEmpresa(Empresas empresa)
        {
            try
            {
                var dataEmpresa = await GetEmpresaById(empresa.EmpId);
                if (dataEmpresa != null)
                {
                    _dataContext.Entry(empresa).State = EntityState.Modified;
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception($"No existe información por ID:{empresa.EmpId}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateEmpresa: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeleteEmpresa(int id)
        {
            try
            {
                var dataEmpresa = await GetEmpresaById(id);
                if (dataEmpresa != null)
                {
                    Models.Empresas empresa = new()
                    {
                        EmpStaffName = dataEmpresa.EmpStaffName,
                        EmpStaffLastName = dataEmpresa.EmpStaffLastName,
                        EmpStaffEmail = dataEmpresa.EmpStaffEmail,
                        EmpStaffPassword = dataEmpresa.EmpStaffPassword,
                        EmpName = dataEmpresa.EmpName,
                        EmpRazonSocial = dataEmpresa.EmpRazonSocial,
                        EmpNumRuc = dataEmpresa.EmpNumRuc,
                        EmpDireccion = dataEmpresa.EmpDireccion,
                        EmpCodPostal = dataEmpresa.EmpCodPostal,
                        EmpNumPhone = dataEmpresa.EmpNumPhone,
                        EmpProfilePicture = dataEmpresa.EmpProfilePicture,
                        EstId = dataEmpresa.EstId,
                        IndId = dataEmpresa.IndId,
                        CantEmpId = dataEmpresa.CantEmpID                        
                    };
                    _dataContext.Entry(empresa).State = EntityState.Modified;
                    return await _dataContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new Exception($"No existe información por el Id: {id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteEmpresa: {ex.Message}");
                throw;
            }
        }
    }
}
