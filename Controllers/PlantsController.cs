using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            return View(new Plant()); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Plant plant)
        {
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null) return NotFound();

            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", plant.CategoryId);
            return View(plant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Plant plant)
        {
            if (id != plant.Id) return NotFound();

            _context.Update(plant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var plant = await _context.Plants
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (plant == null) return NotFound();

            return View(plant);
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