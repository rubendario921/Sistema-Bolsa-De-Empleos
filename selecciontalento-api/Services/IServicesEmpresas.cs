namespace selecciontalento_api.Services
{
    public interface IServicesEmpresas
    {
        Task<IEnumerable<DTOs.EmpresasDTO>> GetAllEmpresas();
        Task<DTOs.EmpresasDTO> GetEmpresaById(int id);
        Task<DTOs.EmpresasDTO> GetEmpresaByNumRuc(string EmpNumRuc);
        Task<bool> SaveEmpresa(Models.Empresas empresa);
        Task<bool> UpdateEmpresa(Models.Empresas empresa);
        Task<bool> DeleteEmpresa(int id);
    }
}
