using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClawWorkouts.Server.Data;
using ClawWorkouts.Shared.Models;

namespace ClawWorkouts.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeightController : ControllerBase
    {
        private readonly WorkoutDbContext _context;

        public WeightController(WorkoutDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeightEntry>>> GetWeights()
        {
            return await _context.WeightEntries.OrderByDescending(w => w.Date).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<WeightEntry>> PostWeight(WeightEntry entry)
        {
            _context.WeightEntries.Add(entry);
            await _context.SaveChangesAsync();
            return Ok(entry);
        }
    }
}
