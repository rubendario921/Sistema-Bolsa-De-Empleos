namespace selecciontalento_api.Services
{
    public interface IServicesCandidatos
    {
        Task<IEnumerable<DTOs.CandidatosDTO>> GetAllCandidatos();
        Task<DTOs.CandidatosDTO> GetCandidatoById(int id);
        Task<DTOs.CandidatosDTO> GetCandidatoByNumDni(string numDni);
        Task<bool> SaveCandidato(Models.Candidatos candidatos);
        Task<bool> UpdateCandidato(Models.Candidatos candidatos);
        Task<bool> DeleteCandidato(Models.Candidatos candidatos);
    }
}
