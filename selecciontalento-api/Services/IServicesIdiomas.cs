namespace selecciontalento_api.Services
{
    public interface IServicesIdiomas
    {
        Task<IEnumerable<DTOs.IdiomasDTO>> GetAllIdiomas();
        Task<DTOs.IdiomasDTO> GetIdiomaById(int id);
        Task<DTOs.IdiomasDTO> GetIdiomaByName(string name);
        Task<bool> SaveIdioma (Models.Idiomas idiomas);
        Task<bool> UpdateIdioma(Models.Idiomas idiomas);
        Task<bool> DeleteIdioma(int id);
    }
}
