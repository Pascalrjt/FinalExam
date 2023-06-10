using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using YourAppName.Models;
using YourAppName.Data;

namespace YourAppName.Controllers
{
    public class AdoptionPlanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptionPlanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdoptionPlan
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdoptionPlans.ToListAsync());
        }

        // GET: AdoptionPlan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdoptionPlan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalId, AdopterName, AdopterEmail")] AdoptionPlan adoptionPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptionPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adoptionPlan);
        }

        // GET: AdoptionPlan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionPlan = await _context.AdoptionPlans.FindAsync(id);
            if (adoptionPlan == null)
            {
                return NotFound();
            }
            return View(adoptionPlan);
        }

        // POST: AdoptionPlan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnimalId,AdopterName,AdopterEmail")] AdoptionPlan adoptionPlan)
        {
            if (id != adoptionPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptionPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionPlanExists(adoptionPlan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adoptionPlan);
        }

        // GET: AdoptionPlan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionPlan = await _context.AdoptionPlans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionPlan == null)
            {
                return NotFound();
            }

            return View(adoptionPlan);
        }

        // POST: AdoptionPlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptionPlan = await _context.AdoptionPlans.FindAsync(id);
            _context.AdoptionPlans.Remove(adoptionPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptionPlanExists(int id)
        {
            return _context.AdoptionPlans.Any(e => e.Id == id);
        }
    }
}
