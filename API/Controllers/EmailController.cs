
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EscuelaContext _context;

        public EmailController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: api/Email
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmails()
        {
            return await _context.Emails.ToListAsync();
        }

        // GET: api/Email/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Email>> GetEmail(string id)
        {
            var email = await _context.Emails.FindAsync(id);

            if (email == null)
            {
                return NotFound();
            }

            return email;
        }

        // PUT: api/Email/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmail(string id, Email email)
        {
            if (id != email.Email1)
            {
                return BadRequest();
            }

            _context.Entry(email).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
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

        // POST: api/Email
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Email>> PostEmail(Email email)
        {
            _context.Emails.Add(email);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmailExists(email.Email1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmail", new { id = email.Email1 }, email);
        }

        // DELETE: api/Email/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail(string id)
        {
            var email = await _context.Emails.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }

            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailExists(string id)
        {
            return _context.Emails.Any(e => e.Email1 == id);
        }
    }
}
