using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flower_Shop.Data;
using Flower_Shop.Models;

namespace Flower_Shop.Controllers
{
    public class PermissionsController : Controller
    {
        private readonly AppDbContext _context;

        public PermissionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Permissions.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Permission permission)
        {
            if (ModelState.IsValid)
            {
                _context.Permissions.Add(permission);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(permission);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var permission = await _context.Permissions.FindAsync(id);

            if (permission == null)
                return NotFound();

            return View(permission);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Permission permission)
        {
            if (id != permission.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(permission);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(permission);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var permission = await _context.Permissions
                .FirstOrDefaultAsync(p => p.Id == id);

            if (permission == null)
                return NotFound();

            return View(permission);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);

            if (permission == null)
                return NotFound();

            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

