using Microsoft.AspNetCore.Mvc;
using ZooShop.Models;
using ZooShop.Logic;
using Microsoft.EntityFrameworkCore;

namespace ZooShop.Controllers
{
    public class PetTypeController : Controller
    {
        private readonly MyDbContext _context;

        public PetTypeController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PetType
        public async Task<IActionResult> Index()
        {
            var petTypes = await _context.PetTypes.ToListAsync();
            return View(petTypes);
        }

        // GET: PetType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] PetType petType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petType);
        }

        // GET: PetType/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var petType = await _context.PetTypes.FindAsync(id);
            if (petType == null)
            {
                return NotFound();
            }
            return View(petType);
        }

        // POST: PetType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name")] PetType petType)
        {
            if (id != petType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.PetTypes.Any(e => e.Id == petType.Id))
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
            return View(petType);
        }

        // GET: PetType/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var petType = await _context.PetTypes.FindAsync(id);
            if (petType == null)
            {
                return NotFound();
            }
            return View(petType);
        }

        // POST: PetType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petType = await _context.PetTypes.FindAsync(id);
            _context.PetTypes.Remove(petType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}