using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Meetings.DAL;
using Meetings.DAL.Entities;

namespace Registration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorEntitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public VisitorEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/VisitorEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitorEntity>>> GetVisitors()
        {
            return await _context.Visitors.ToListAsync();
        }

        // GET: api/VisitorEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitorEntity>> GetVisitorEntity(long id)
        {
            var visitorEntity = await _context.Visitors.FindAsync(id);

            if (visitorEntity == null)
            {
                return NotFound();
            }

            return visitorEntity;
        }

        // PUT: api/VisitorEntities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitorEntity(long id, VisitorEntity visitorEntity)
        {
            if (id != visitorEntity.VisitorId)
            {
                return BadRequest();
            }

            _context.Entry(visitorEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorEntityExists(id))
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

        // POST: api/VisitorEntities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VisitorEntity>> PostVisitorEntity(VisitorEntity visitorEntity)
        {
            _context.Visitors.Add(visitorEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisitorEntity", new { id = visitorEntity.VisitorId }, visitorEntity);
        }

        // DELETE: api/VisitorEntities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VisitorEntity>> DeleteVisitorEntity(long id)
        {
            var visitorEntity = await _context.Visitors.FindAsync(id);
            if (visitorEntity == null)
            {
                return NotFound();
            }

            _context.Visitors.Remove(visitorEntity);
            await _context.SaveChangesAsync();

            return visitorEntity;
        }

        private bool VisitorEntityExists(long id)
        {
            return _context.Visitors.Any(e => e.VisitorId == id);
        }
    }
}
