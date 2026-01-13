using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantTracker3NET.Data;
using PlantTracker3NET.Models;

namespace PlantTracker3NET.Controllers
{
    public class GardenToolsController : Controller
    {
        private readonly AppDbContext _context;
        public GardenToolsController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            return View(await _context.GardenTools.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(GardenTool tool)
        {
            _context.GardenTools.Add(tool);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tool = await _context.GardenTools.FindAsync(id);
            if (tool != null)
            {
                _context.GardenTools.Remove(tool);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}