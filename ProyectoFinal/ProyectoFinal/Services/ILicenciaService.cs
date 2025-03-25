using DB;

namespace ProyectoFinal.Services
{
    public interface ILicenciaService
    {
        Task<IEnumerable<Licencia>> GetLicenciasAsync();
        Task<Licencia> CreateLicenciaAsync(Licencia nuevaLicencia);
        Task<Licencia> UpdateLicenciaAsync(string dni, Licencia licenciaNueva);
        Task<bool> DeleteLicenciaAsync(string dniBuscado);
    }
}
