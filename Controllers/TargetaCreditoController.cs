using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetaCreditoController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public TargetaCreditoController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TargetaCredito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TargetaCredito>>> GetTarjetaCredito()
        {
            return await _context.TarjetaCredito.ToListAsync();
        }

        // GET: api/TargetaCredito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TargetaCredito>> GetTargetaCredito(int id)
        {
            var targetaCredito = await _context.TarjetaCredito.FindAsync(id);

            if (targetaCredito == null)
            {
                return NotFound();
            }

            return targetaCredito;
        }

        // PUT: api/TargetaCredito/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTargetaCredito(int id, TargetaCredito targetaCredito)
        {
            if (id != targetaCredito.Id)
            {
                return BadRequest();
            }

            _context.Entry(targetaCredito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TargetaCreditoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TargetaCredito
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TargetaCredito>> PostTargetaCredito(TargetaCredito targetaCredito)
        {
            _context.TarjetaCredito.Add(targetaCredito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTargetaCredito", new { id = targetaCredito.Id }, targetaCredito);
        }

        // DELETE: api/TargetaCredito/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTargetaCredito(int id)
        {
            var targetaCredito = await _context.TarjetaCredito.FindAsync(id);
            if (targetaCredito == null)
            {
                return NotFound();
            }

            _context.TarjetaCredito.Remove(targetaCredito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TargetaCreditoExists(int id)
        {
            return _context.TarjetaCredito.Any(e => e.Id == id);
        }
    }
}
