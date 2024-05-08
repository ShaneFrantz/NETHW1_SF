using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuartetScoreManager.Databases;
using QuartetScoreManager.Models;

namespace QuartetScoreManager.Controllers
{
    public class QuartetScoresController : Controller
    {
        private readonly QuartetScoreDbContext _context;

        public QuartetScoresController(QuartetScoreDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var quartetScoresList = await _context.QuartetScores.ToListAsync();
            return View(quartetScoresList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuartetScore quartetScore)
        {
            if (ModelState.IsValid) 
            {
                _context.QuartetScores.Add(quartetScore);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(quartetScore);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }

            var quartetScore = await _context.QuartetScores.FindAsync(id);
            if (quartetScore == null) 
            {
                return NotFound();
            }
            return View(quartetScore);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(QuartetScore quartetScore)
        {
            if (ModelState.IsValid)
            {
                _context.QuartetScores.Update(quartetScore);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quartetScore = await _context.QuartetScores.FirstOrDefaultAsync(q => q.Id == id);
            if (quartetScore == null)
            {
                return NotFound();
            }
            return View(quartetScore);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var quartetScore = await _context.QuartetScores.FindAsync(id);
            _context.QuartetScores.Remove(quartetScore);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
