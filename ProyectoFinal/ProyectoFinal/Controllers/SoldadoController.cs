using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldadoController : ControllerBase
    {
        private ProyectoFinalContext _context;

        public SoldadoController(ProyectoFinalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Soldado> GetSoldados() => _context.Soldados.ToList();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Soldado nuevoSoldado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Add(nuevoSoldado);
                await _context.SaveChangesAsync(); 

                return Ok("Soldado agregado");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error 500 al agregar a un soldado");
            }
        }
    }


}

/*
 hacer una biblioteca de clases, la cual va a tener a una clase genercia 
de ahi solo hago el add y el save and sync, luego lo llamo aca y listo, preguntarle a lucas anca
 
 
 
 */


