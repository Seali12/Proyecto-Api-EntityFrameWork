using System.Data.Entity;
using System.Net;
using DataAccess.Generic;
using DB;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace ProyectoFinal.Services
{
    public class LicenciaService : ILicenciaService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Licencia> _genericLicencia;

        public LicenciaService(IUnitOfWork unitOfWork, IGenericRepository<Licencia> genericLicencia)
        {
            _unitOfWork = unitOfWork;
            _genericLicencia = genericLicencia;
        }

        public async Task<IEnumerable<Licencia>> GetLicenciasAsync()
        {
            return  _unitOfWork.Context.Licencias.ToList();
        }

        public async Task<Licencia> CreateLicenciaAsync(Licencia nuevaLicencia)
        {
            await _genericLicencia.Create(nuevaLicencia);
            return nuevaLicencia;
        }
        public async Task<Licencia> UpdateLicenciaAsync(int dni, Licencia licenciaNueva)
        {
            var licenciaBuscada = _unitOfWork.Context.Licencias.FirstOrDefault(b => b.SoldadoDni == dni);

            if (licenciaBuscada == null)
            {
                return null;
            }

            if (licenciaNueva.fechaInicio != DateTime.Now)
            {
                licenciaBuscada.fechaInicio = licenciaNueva.fechaInicio; 
                _unitOfWork.Context.Entry(licenciaBuscada).Property(x => x.fechaInicio).IsModified = true;
            }

            if (licenciaNueva.fechaFin != DateTime.Now)
            {
                licenciaBuscada.fechaFin = licenciaBuscada.fechaFin;
                _unitOfWork.Context.Entry(licenciaBuscada).Property(x => x.fechaFin).IsModified = true;
            }

            if (licenciaNueva.tipo != "string")
            {
                licenciaBuscada.tipo = licenciaBuscada.tipo;
                _unitOfWork.Context.Entry(licenciaBuscada).Property(x => x.tipo).IsModified = true;
            }

            if (licenciaNueva.localidad != "string")
            {
                licenciaBuscada.localidad = licenciaNueva.localidad;
                _unitOfWork.Context.Entry(licenciaBuscada).Property(x => x.localidad).IsModified = true;
            }

            if (licenciaNueva.direccion != "string")
            {
                licenciaBuscada.direccion = licenciaNueva.direccion;
                _unitOfWork.Context.Entry(licenciaBuscada).Property(x => x.direccion).IsModified = true;
            }

            if (licenciaNueva.ordenDelDia != "string"){
                licenciaBuscada.ordenDelDia = licenciaNueva.ordenDelDia;
                _unitOfWork.Context.Entry(licenciaBuscada).Property(x => x.ordenDelDia).IsModified = true;
            }


            await _unitOfWork.Context.SaveChangesAsync();

            return licenciaBuscada;
        }
  
        public async Task<bool> DeleteLicenciaAsync(int dniBuscado)
        {
           
            var licenciaBuscada = _unitOfWork.Context.Licencias.FirstOrDefault(b => b.SoldadoDni == dniBuscado);
            if (licenciaBuscada == null)
            {
                return false;
            }
           
            await _genericLicencia.Delete(licenciaBuscada);
            return true;

          
        }
    }
}
