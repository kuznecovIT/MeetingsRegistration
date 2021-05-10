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
    public class ActivityEntitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public ActivityEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ActivityEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityEntity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        // GET: api/ActivityEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityEntity>> GetActivityEntity(long id)
        {
            var activityEntity = await _context.Activities.FindAsync(id);

            if (activityEntity == null)
            {
                return NotFound();
            }

            return activityEntity;
        }

        // PUT: api/ActivityEntities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityEntity(long id, ActivityEntity activityEntity)
        {
            if (id != activityEntity.ActivityId)
            {
                return BadRequest();
            }

            _context.Entry(activityEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityEntityExists(id))
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

        // POST: api/ActivityEntities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ActivityEntity>> PostActivityEntity(ActivityEntity activityEntity)
        {
            _context.Activities.Add(activityEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityEntity", new { id = activityEntity.ActivityId }, activityEntity);
        }

        // DELETE: api/ActivityEntities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityEntity>> DeleteActivityEntity(long id)
        {
            var activityEntity = await _context.Activities.FindAsync(id);
            if (activityEntity == null)
            {
                return NotFound();
            }

            _context.Activities.Remove(activityEntity);
            await _context.SaveChangesAsync();

            return activityEntity;
        }

        private bool ActivityEntityExists(long id)
        {
            return _context.Activities.Any(e => e.ActivityId == id);
        }
    }
}
