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
    public class MeetingEntitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public MeetingEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MeetingEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingEntity>>> GetMeetings()
        {
            return await _context.Meetings.ToListAsync();
        }

        // GET: api/MeetingEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingEntity>> GetMeetingEntity(long id)
        {
            var meetingEntity = await _context.Meetings.FindAsync(id);

            if (meetingEntity == null)
            {
                return NotFound();
            }

            return meetingEntity;
        }

        // PUT: api/MeetingEntities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetingEntity(long id, MeetingEntity meetingEntity)
        {
            if (id != meetingEntity.MeetingId)
            {
                return BadRequest();
            }

            _context.Entry(meetingEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingEntityExists(id))
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

        // POST: api/MeetingEntities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MeetingEntity>> PostMeetingEntity(MeetingEntity meetingEntity)
        {
            _context.Meetings.Add(meetingEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeetingEntity", new { id = meetingEntity.MeetingId }, meetingEntity);
        }

        // DELETE: api/MeetingEntities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeetingEntity>> DeleteMeetingEntity(long id)
        {
            var meetingEntity = await _context.Meetings.FindAsync(id);
            if (meetingEntity == null)
            {
                return NotFound();
            }

            _context.Meetings.Remove(meetingEntity);
            await _context.SaveChangesAsync();

            return meetingEntity;
        }

        private bool MeetingEntityExists(long id)
        {
            return _context.Meetings.Any(e => e.MeetingId == id);
        }
    }
}
