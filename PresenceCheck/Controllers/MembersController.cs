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
    public class MembersController : ControllerBase
    {
        #region variables
        private readonly AppDBContext _context;

        public MembersController(AppDBContext context)
        {
            _context = context;
        }
        #endregion
        
        #region get members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }
        #endregion
        
        #region get member by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(long id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }
        #endregion
        
        #region update member detail
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(long id, Member member)
        {
            if (id != member.id)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        #region create memebr
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            _context.Database.OpenConnection();
            try
            {
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Members ON");
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
                _context.SaveChanges();
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Members OFF");
            }
            finally
            {
                _context.Database.CloseConnection();
            }
            
            return CreatedAtAction("GetMember", new { id = member.id }, member);
        }
        #endregion
        
        #region delete memebr
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(long id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        
        #region member exist
        private bool MemberExists(long id)
        {
            return _context.Members.Any(e => e.id == id);
        }
        #endregion
    }
}
