using DB;

namespace ProyectoFinal.Services
{
    public interface ILicenciaService
    {
        Task<IEnumerable<Licencia>> GetLicenciasAsync();
        Task<Licencia> CreateLicenciaAsync(Licencia nuevaLicencia);
        Task<Licencia> UpdateLicenciaAsync(int dni, Licencia licenciaNueva);
        Task<bool> DeleteLicenciaAsync(int dniBuscado);
    }
}
