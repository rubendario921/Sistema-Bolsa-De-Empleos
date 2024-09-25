namespace selecciontalento_api.Services
{
    public interface IServicesIndustrias
    {
        Task<IEnumerable<DTOs.IndustriasDTO>> GetAllIndustrias();
        Task<DTOs.IndustriasDTO> GetIndustriaById(int id);
        Task<DTOs.IndustriasDTO> GetIndustriaByName(string name);
        Task<bool> SaveIndustria(Models.Industrias industria);
        Task<bool> UpdateIndustria(Models.Industrias industria);
        Task<bool> DeleteIndustria(int id);
    }
}
