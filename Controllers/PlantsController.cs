using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantTracker3NET.Data;
using PlantTracker3NET.Models;

namespace PlantTracker3NET.Controllers
{
    public class PlantsController : Controller
    {
        private readonly AppDbContext _context;
        public PlantsController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var plants = await _context.Plants.Include(p => p.Category).ToListAsync();
            return View(plants);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Plant plant)
        {
            if (!ModelState.IsValid) return View(plant);
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null) return NotFound();
            return View(plant);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Plant plant)
        {
            if (!ModelState.IsValid) return View(plant);
            _context.Plants.Update(plant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant != null)
            {
                _context.Plants.Remove(plant);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
