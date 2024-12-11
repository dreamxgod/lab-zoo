using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooShop.Models;
using ZooShop.Logic;

namespace ZooShop.Controllers
{
    public class PetController : Controller
    {
        private readonly MyDbContext _context;

        public PetController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Pet
        public async Task<IActionResult> Index()
        {
            var pets = await _context.Pets.Include(p => p.Type).ToListAsync();
            return View(pets);
        }

        // GET: Pet/Create
        public IActionResult Create()
        {
            var petTypes = _context.PetTypes.ToList();
            ViewData["PetTypes"] = petTypes;
            return View();
        }

        // POST: Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Age, TypeId")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var petTypes = _context.PetTypes.ToList();
            ViewData["PetTypes"] = petTypes;
            return View(pet);
        }

        // GET: Pet/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            var petTypes = _context.PetTypes.ToList();
            ViewData["PetTypes"] = petTypes;
            return View(pet);
        }

        // POST: Pet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Age, TypeId")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Pets.Any(e => e.Id == pet.Id))
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
            var petTypes = _context.PetTypes.ToList();
            ViewData["PetTypes"] = petTypes;
            return View(pet);
        }

        // GET: Pet/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var pet = await _context.Pets.Include(p => p.Type).FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        // POST: Pet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}