using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurismoComunitario.Server.Models;

namespace TurismoComunitario.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CrearReserva([FromBody] Reserva reserva)
        {
            try
            {
                _context.Reservas.Add(reserva);
                await _context.SaveChangesAsync();
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al guardar la reserva" + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerReservas()
        {
            var reservas = await _context.Reservas.ToListAsync();
            return Ok(reservas);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
