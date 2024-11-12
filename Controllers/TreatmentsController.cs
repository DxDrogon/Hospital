using Hospital.Context;
using Hospital.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        private readonly HospitalContext _context;

        public TreatmentsController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treatment>>> Gettreatments()
        {
            return await _context.Treatments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Treatment>> Gettreatment(int id)
        {
            var treatment = await _context.Treatments.FindAsync(id);

            if (treatment == null)
            {
                return NotFound();
            }

            return treatment;
        }

        [HttpPost]
        public async Task<ActionResult<Treatment>> Posttreatment(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Gettreatment), new { id = treatment.Id }, treatment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Puttreatment(int id, Treatment treatment)
        {
            if (id != treatment.Id)
            {
                return BadRequest();
            }

            _context.Entry(treatment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetreatment(int id)
        {
            var treatment = await _context.Treatments.FindAsync(id);
            if (treatment == null)
            {
                return NotFound();
            }

            _context.Treatments.Remove(treatment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
