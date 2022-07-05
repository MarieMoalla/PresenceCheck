using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresenceCheck.Data;
using PresenceCheck.Entities;

namespace PresenceCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        #region variables
        private readonly AppDBContext _context;

        public MeetingsController(AppDBContext context)
        {
            _context = context;
        }
        #endregion
        
        #region get meetings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetings()
        {
            return await _context.Meetings.ToListAsync();
        }
        #endregion
        
        #region get meeting by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Meeting>> GetMeeting(long id)
        {
            var meeting = await _context.Meetings.FindAsync(id);

            if (meeting == null)
            {
                return NotFound();
            }

            return meeting;
        }
        #endregion
        
        #region update meeting
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeeting(long id, Meeting meeting)
        {
            if (id != meeting.id)
            {
                return BadRequest();
            }

            _context.Entry(meeting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingExists(id))
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
        #endregion
        
        #region create meeting
        [HttpPost]
        public async Task<ActionResult<Meeting>> PostMeeting(Meeting meeting)
        {
            _context.Meetings.Add(meeting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeeting", new { id = meeting.id }, meeting);
        }
        #endregion
        
        #region delete meeting
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(long id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        
        #region meetings exist
        private bool MeetingExists(long id)
        {
            return _context.Meetings.Any(e => e.id == id);
        }
        #endregion
    }
}
