namespace selecciontalento_api.Services
{
    public interface IServicesCantidadEmpleados
    {
        Task<IEnumerable<DTOs.CantidadEmpleadosDTO>> GetAllCantidadEmpleados();
        Task<DTOs.CantidadEmpleadosDTO> GetCantidadEmpleadoById(int id);
        Task<DTOs.CantidadEmpleadosDTO> GetCantidadEmpleadoByName(string name);
        Task<bool> SaveCantidadEmpleados(Models.CantidadEmpleados cantidadEmpleado);
        Task<bool> UpdateCantidadEmpleados(Models.CantidadEmpleados cantidadEmpleado);
        Task<bool> DeleteCantidadEmpleados(int id);
    }
}
