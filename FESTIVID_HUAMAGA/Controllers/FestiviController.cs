/**using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FESTIVID_HUAMAGA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestiviController : ControllerBase
    {
    }
}


*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FESTIVID_HUAMAGA.Models;

namespace FESTIVID_HUAMAGA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestividadesController : ControllerBase
    {
        private readonly BD_centralContext _context;

        public FestividadesController(BD_centralContext context)
        {
            _context = context;
        }

        // GET: api/Festividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festividades>>> GetFestividades()
        {
            return await _context.Festividades.ToListAsync();
        }

        // GET: api/Festividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Festividades>> GetFestividades(int id)
        {
            var festividades = await _context.Festividades.FindAsync(id);

            if (festividades == null)
            {
                return NotFound();
            }

            return festividades;
        }

        // PUT: api/Festividades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFestividades(int id, Festividades festividades)
        {
            if (id != festividades.Id)
            {
                return BadRequest();
            }

            _context.Entry(festividades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FestividadesExists(id))
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

        // POST: api/Festividades
        [HttpPost]
        public async Task<ActionResult<Festividades>> PostFestividades(Festividades festividades)
        {
            _context.Festividades.Add(festividades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFestividades", new { id = festividades.Id }, festividades);
        }

        // DELETE: api/Festividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFestividades(int id)
        {
            var festividades = await _context.Festividades.FindAsync(id);
            if (festividades == null)
            {
                return NotFound();
            }

            _context.Festividades.Remove(festividades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FestividadesExists(int id)
        {
            return _context.Festividades.Any(e => e.Id == id);
        }
    }
}