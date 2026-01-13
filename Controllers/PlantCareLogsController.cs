using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlantTracker3NET.Data;
using PlantTracker3NET.Models;

namespace PlantTracker3NET.Controllers
{
    public class PlantCareLogsController : Controller
    {
        private readonly AppDbContext _context;
        public PlantCareLogsController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var logs = await _context.PlantCareLogs.Include(p => p.Plant).ToListAsync();
            return View(logs);
        }

        public IActionResult Create()
        {
            ViewBag.PlantId = new SelectList(_context.Plants, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlantCareLog log)
        {
            if (ModelState.IsValid)
            {
                _context.PlantCareLogs.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.PlantId = new SelectList(_context.Plants, "Id", "Name", log.PlantId);
            return View(log);
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