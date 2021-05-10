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
    public class MeetingVisitorEntitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public MeetingVisitorEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MeetingVisitorEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingVisitorEntity>>> GetMeetingVisitors()
        {
            return await _context.MeetingVisitors.ToListAsync();
        }

        // GET: api/MeetingVisitorEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingVisitorEntity>> GetMeetingVisitorEntity(long id)
        {
            var meetingVisitorEntity = await _context.MeetingVisitors.FindAsync(id);

            if (meetingVisitorEntity == null)
            {
                return NotFound();
            }

            return meetingVisitorEntity;
        }

        // PUT: api/MeetingVisitorEntities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetingVisitorEntity(long id, MeetingVisitorEntity meetingVisitorEntity)
        {
            if (id != meetingVisitorEntity.MeetingVisitorId)
            {
                return BadRequest();
            }

            _context.Entry(meetingVisitorEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingVisitorEntityExists(id))
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

        // POST: api/MeetingVisitorEntities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MeetingVisitorEntity>> PostMeetingVisitorEntity(MeetingVisitorEntity meetingVisitorEntity)
        {
            _context.MeetingVisitors.Add(meetingVisitorEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeetingVisitorEntity", new { id = meetingVisitorEntity.MeetingVisitorId }, meetingVisitorEntity);
        }

        // DELETE: api/MeetingVisitorEntities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeetingVisitorEntity>> DeleteMeetingVisitorEntity(long id)
        {
            var meetingVisitorEntity = await _context.MeetingVisitors.FindAsync(id);
            if (meetingVisitorEntity == null)
            {
                return NotFound();
            }

            _context.MeetingVisitors.Remove(meetingVisitorEntity);
            await _context.SaveChangesAsync();

            return meetingVisitorEntity;
        }

        private bool MeetingVisitorEntityExists(long id)
        {
            return _context.MeetingVisitors.Any(e => e.MeetingVisitorId == id);
        }
    }
}
