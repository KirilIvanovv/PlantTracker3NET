using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlantTracker3NET.Data;
using PlantTracker3NET.Models;

namespace PlantTracker3NET.Controllers
{
    public class PlantNotesController : Controller
    {
        private readonly AppDbContext _context;
        public PlantNotesController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var notes = await _context.PlantNotes.Include(p => p.Plant).ToListAsync();
            return View(notes);
        }

        public IActionResult Create()
        {
            ViewBag.PlantId = new SelectList(_context.Plants, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlantNote note)
        {
            if (ModelState.IsValid)
            {
                _context.PlantNotes.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.PlantId = new SelectList(_context.Plants, "Id", "Name", note.PlantId);
            return View(note);
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