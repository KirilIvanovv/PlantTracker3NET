using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantTracker3NET.Data;
using PlantTracker3NET.Models;

namespace PlantTracker3NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlantsApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plant>>> GetPlants()
        {
            return await _context.Plants
                .Include(p => p.Category) 
                .Include(p => p.Notes)    
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plant>> GetPlant(int id)
        {
            var plant = await _context.Plants
                .Include(p => p.Category)
                .Include(p => p.CareLogs) 
                .FirstOrDefaultAsync(p => p.Id == id);

            if (plant == null) return NotFound();
            return plant;
        }

        [HttpPost]
        public async Task<ActionResult<Plant>> PostPlant(Plant plant)
        {
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlant), new { id = plant.Id }, plant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null) return NotFound();

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}