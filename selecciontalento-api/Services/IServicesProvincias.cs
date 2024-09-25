namespace selecciontalento_api.Services
{
    public interface IServicesProvincias
    {
        Task<IEnumerable<Models.Provincias>> GetAllProvincias();
        Task<Models.Provincias> GetProvinciaById(int id);
        Task<Models.Provincias> GetProvinciaByName(string name);
        Task<bool> SaveProvincia(Models.Provincias provincia);
        Task<bool> UpdateProvincia(Models.Provincias provincia);
        Task<bool> DeleteProvincia(int id);
    }
}
