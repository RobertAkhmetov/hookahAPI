using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiForHookahv1._0.Models;

namespace WebApiForHookahv1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly HookaContext _context;

        public ReviewsController(HookaContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public IEnumerable<Hooka> GetHookas()
        {
            return _context.Hookas;
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHooka([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hooka = await _context.Hookas.FindAsync(id);

            if (hooka == null)
            {
                return NotFound();
            }

            return Ok(hooka);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHooka([FromRoute] int id, [FromBody] Hooka hooka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hooka.Id)
            {
                return BadRequest();
            }

            _context.Entry(hooka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HookaExists(id))
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

        // POST: api/Reviews
        [HttpPost]
        public async Task<IActionResult> PostHooka([FromBody] Hooka hooka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Hookas.Add(hooka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHooka", new { id = hooka.Id }, hooka);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHooka([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hooka = await _context.Hookas.FindAsync(id);
            if (hooka == null)
            {
                return NotFound();
            }

            _context.Hookas.Remove(hooka);
            await _context.SaveChangesAsync();

            return Ok(hooka);
        }

        private bool HookaExists(int id)
        {
            return _context.Hookas.Any(e => e.Id == id);
        }
    }
}