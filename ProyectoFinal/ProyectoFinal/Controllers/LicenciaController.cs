using System.Net;
using DataAccess.Generic;
using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenciaController : ControllerBase
    {

        private readonly IGenericRepository<Licencia> genericLicencia;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILicenciaService licenciaService;


        public LicenciaController(IGenericRepository<Licencia> context, IUnitOfWork work,ILicenciaService service)

        {
            genericLicencia = context;
            unitOfWork = work;
            licenciaService = service;
        }

        /// <summary>
        ///  Devuelve todas las licencias que existen en la tabla licencia
        /// </summary>
        /// <remarks>
        /// Por ejemplo:
        ///
        /// GET /api/licencias
        ///
        /// La respuesta obtenida será del tipo:
        ///
        /// [
        ///           {
        ///     "licenciaId": 0,
        ///     "soldadoId": 0,
        ///     "soldado": {
        ///       "soldadoId": 0,
        ///       "nombre": "string",
        ///       "apellido": "string",
        ///       "dni": 999999999
        ///     },
        ///     "soldadoDni": 0,
        ///     "fechaInicio": "2025-03-18T11:29:19.434Z",
        ///     "fechaFin": "2025-03-18T11:29:19.434Z",
        ///     "tipo": "string",
        ///     "provincia": "string",
        ///     "localidad": "string",
        ///     "direccion": "string",
        ///     "ordenDelDia": "string"
        ///   }
        /// ]
        ///
        /// </remarks>
        /// <response code="200">
        /// Respuesta exitosa.
        ///
        /// Código: 200
        /// Mensaje: "Un mensaje de confirmación"
        /// Contenido: Lista de licencias solicitadas
        ///
        /// </response>
        /// <response code="400">
        /// Se realizó mal la consulta.
        ///
        /// Código: 400
        /// Mensaje: "Un mensaje de error"
        /// Contenido: null
        ///
        /// </response>
        /// <response code="404">
        /// No se encontro información que cumpla con lo solicitado.
        ///
        /// Código: 404
        /// Mensaje: "Un mensaje de error de busqueda"
        /// Contenido: null
        ///
        /// </response>
        /// <response code="500">
        /// Error en el servidor.
        ///
        /// Código: 500
        /// Mensaje: "Ha ocurrido un error desconocido."
        /// Contenido: null
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Licencia>>> GetLicencia()
        {
            try
            {
                var licencias = await licenciaService.GetLicenciasAsync();
                return Ok(licencias);
            }
            catch (Exception ex)
            {
                // Podés loguear el error si querés, usando ILogger, por ejemplo.
                return StatusCode(500, "Ocurrió un error al obtener las licencias.");
            }
        }

        /// <summary>
        ///  Crea una nueva licencia
        /// </summary>
        /// <remarks>
        /// Por ejemplo:
        ///
        /// POST /api/licencias
        ///
        /// [
        ///           {
        ///     "licenciaId": 0,
        ///     "soldadoId": 0,
        ///     "soldado": {
        ///       "soldadoId": 0,
        ///       "nombre": "string",
        ///       "apellido": "string",
        ///       "dni": 999999999
        ///     },
        ///     "soldadoDni": 0,
        ///     "fechaInicio": "2025-03-18T11:29:19.434Z",
        ///     "fechaFin": "2025-03-18T11:29:19.434Z",
        ///     "tipo": "string",
        ///     "provincia": "string",
        ///     "localidad": "string",
        ///     "direccion": "string",
        ///     "ordenDelDia": "string"
        ///   }
        /// ]
        ///
        /// </remarks>
        /// <response code="200">
        /// Respuesta exitosa.
        ///
        /// Código: 200
        /// Mensaje: "Un mensaje de confirmación"
        /// Contenido: licencia creada correctamente
        /// </response>
        /// <response code="400">
        /// Se realizó mal la consulta.
        ///
        /// Código: 400
        /// Mensaje: "Un mensaje de error"
        /// Contenido: null
        ///
        /// </response>
        /// <response code="404">
        /// No se encontro información que cumpla con lo solicitado.
        /// </response>
        /// <response code="500">
        /// Error en el servidor.
        ///
        /// Código: 500
        /// Mensaje: "Ha ocurrido un error desconocido."
        /// Contenido: null
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Licencia nuevaLicencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var licecencia = await licenciaService.CreateLicenciaAsync(nuevaLicencia);


                return Ok("licencia agregada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error 500 al agregar a una licencia");
            }
        }

        /// <summary>
        ///  Busca mediante un dni la licencia, correspondiente a un soldado
        ///  y permite modificar los campos de la licencia (menos los id)
        /// </summary>
        /// <remarks>
        /// Por ejemplo:
        ///
        /// PUT /api/licencias/{dni}
        ///
        /// [
        ///           {
        ///     "licenciaId": 0,
        ///     "soldadoId": 0,
        ///     "soldado": {
        ///       "soldadoId": 0,
        ///       "nombre": "string",
        ///       "apellido": "string",
        ///       "dni": 999999999
        ///     },
        ///     "soldadoDni": 0,
        ///     "fechaInicio": "2025-03-18T11:29:19.434Z",
        ///     "fechaFin": "2025-03-18T11:29:19.434Z",
        ///     "tipo": "string",
        ///     "provincia": "string",
        ///     "localidad": "string",
        ///     "direccion": "string",
        ///     "ordenDelDia": "string"
        ///   }
        /// ]
        ///
        /// </remarks>
        /// <response code="200">
        /// Respuesta exitosa.
        ///
        /// Código: 200
        /// Mensaje: "Un mensaje de confirmación"
        /// Contenido: licencia creada correctamente
        /// </response>
        /// <response code="400">
        /// Se realizó mal la consulta.
        ///
        /// Código: 400
        /// Mensaje: "Un mensaje de error"
        /// Contenido: null
        ///
        /// </response>
        /// <response code="404">
        /// No se encontro información que cumpla con lo solicitado.
        /// </response>
        /// <response code="500">
        /// Error en el servidor.
        ///
        /// Código: 500
        /// Mensaje: "Ha ocurrido un error desconocido."
        /// Contenido: null
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Licencia licenciaNueva)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var licenciaBuscada = await licenciaService.UpdateLicenciaAsync(licenciaNueva.SoldadoDni, licenciaNueva);
                if (licenciaBuscada == null)
                {
                    return NotFound("No se encontró la licencia a actualizar");
                }
                return Ok("Se actualizo correctamente el soldado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al querer actualizar la licencia: " + ex.Message);
            }
        }

        /// <summary>
        ///  Elimina segun un dni las licencias que existen en la tabla licencia ligadas al dni
        /// </summary>
        /// <remarks>
        /// Por ejemplo:
        ///
        /// DELETE /api/licencias
        ///
        /// La respuesta obtenida será del tipo: eliminacion exitosa
        /// Si no se encuentra la licencia o dni: no se encontro la licencia 
        ///
        /// </remarks>
        /// <response code="200">
        /// Respuesta exitosa.
        ///
        /// Código: 200
        /// Mensaje: "Un mensaje de confirmación"
        /// Contenido: Lista de licencias solicitadas
        ///
        /// </response>
        /// <response code="400">
        /// Se realizó mal la consulta.
        ///
        /// Código: 400
        /// Mensaje: "Un mensaje de error"
        /// Contenido: null
        ///
        /// </response>
        /// <response code="404">
        /// No se encontro información que cumpla con lo solicitado.
        ///
        /// Código: 404
        /// Mensaje: "Un mensaje de error de busqueda"
        /// Contenido: null
        ///
        /// </response>
        /// <response code="500">
        /// Error en el servidor.
        ///
        /// Código: 500
        /// Mensaje: "Ha ocurrido un error desconocido."
        /// Contenido: null
        [HttpDelete]
        public async Task<IActionResult> Delete(int dniBuscado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //await genericLicencia.Delete(licenciaBuscada);
                var bool_licencia = await licenciaService.DeleteLicenciaAsync(dniBuscado);
                return Ok("Eliminacion de licencia ejecutada perfectamente");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error al querer actualizar la licencia");
            }
        }
    }
}
