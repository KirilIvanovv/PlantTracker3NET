using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantTracker3NET.Data;
using PlantTracker3NET.Models;

namespace PlantTracker3NET.Controllers
{
    public class PlantCareLogsController : Controller
    {
        private readonly AppDbContext _context;
        public PlantCareLogsController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index() =>
            View(await _context.PlantCareLogs.Include(l => l.Plant).ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(PlantCareLog log)
        {
            if (!ModelState.IsValid) return View(log);
            _context.PlantCareLogs.Add(log);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var log = await _context.PlantCareLogs.FindAsync(id);
            if (log == null) return NotFound();
            return View(log);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PlantCareLog log)
        {
            if (!ModelState.IsValid) return View(log);
            _context.PlantCareLogs.Update(log);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var log = await _context.PlantCareLogs.FindAsync(id);
            if (log != null)
            {
                _context.PlantCareLogs.Remove(log);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
