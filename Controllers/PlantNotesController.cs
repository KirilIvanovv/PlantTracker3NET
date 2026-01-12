using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantTracker3NET.Data;
using PlantTracker3NET.Models;

namespace PlantTracker3NET.Controllers
{
    public class PlantNotesController : Controller
    {
        private readonly AppDbContext _context;
        public PlantNotesController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index() =>
            View(await _context.PlantNotes.Include(n => n.Plant).ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(PlantNote note)
        {
            if (!ModelState.IsValid) return View(note);
            _context.PlantNotes.Add(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var note = await _context.PlantNotes.FindAsync(id);
            if (note == null) return NotFound();
            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PlantNote note)
        {
            if (!ModelState.IsValid) return View(note);
            _context.PlantNotes.Update(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var note = await _context.PlantNotes.FindAsync(id);
            if (note != null)
            {
                _context.PlantNotes.Remove(note);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
