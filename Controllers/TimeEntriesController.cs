using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeBillingSystemProject.Data;
using TimeBillingSystemProject.Models;

namespace TimeBillingSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntriesController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        // GET: api/timeentries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeEntry>>> GetTimeEntries()
        {
            return await _context.TimeEntries.Include(te => te.Project).ToListAsync();
        }

        // GET: api/timeentries/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeEntry>> GetTimeEntry(int id)
        {
            var timeEntry = await _context.TimeEntries.Include(te => te.Project).FirstOrDefaultAsync(te => te.TimeEntryId == id);
            if (timeEntry == null)
            {
                return NotFound();
            }
            return timeEntry;
        }

        // POST: api/timeentries
        [HttpPost]
        public async Task<ActionResult<TimeEntry>> PostTimeEntry(TimeEntry timeEntry)
        {
            _context.TimeEntries.Add(timeEntry);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTimeEntry), new { id = timeEntry.TimeEntryId }, timeEntry);
        }

        // PUT: api/timeentries/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeEntry(int id, TimeEntry timeEntry)
        {
            if (id != timeEntry.TimeEntryId)
            {
                return BadRequest();
            }
            _context.Entry(timeEntry).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/timeentries/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeEntry(int id)
        {
            var timeEntry = await _context.TimeEntries.FindAsync(id);
            if (timeEntry == null)
            {
                return NotFound();
            }
            _context.TimeEntries.Remove(timeEntry);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

