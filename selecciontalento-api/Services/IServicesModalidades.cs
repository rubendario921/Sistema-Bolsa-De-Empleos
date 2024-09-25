namespace selecciontalento_api.Services
{
    public interface IServicesModalidades
    {
        Task<IEnumerable<DTOs.ModalidadesDTO>> GetAllModalidades();
        Task<DTOs.ModalidadesDTO> GetModalidadById(int id);
        Task<DTOs.ModalidadesDTO> GetModalidadByName(string name);
        Task<bool> SaveModalidad(Models.Modalidades modalidad);
        Task<bool> UpdateModalidad(Models.Modalidades modalidad);
        Task<bool> DeleteModalidad(int id);
    }
}
