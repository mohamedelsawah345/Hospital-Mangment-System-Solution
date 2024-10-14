using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_DAL.Entites;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class Medical_equipmentController : Controller
    {
        private readonly ApplicationDBcontext _context;

        public Medical_equipmentController(ApplicationDBcontext context)
        {
            _context = context;
        }

        // GET: Medical_equipment
        public async Task<IActionResult> Index()
        {
            var applicationDBcontext = _context.medical_Equipment.Include(m => m.Department);
            return View(await applicationDBcontext.ToListAsync());
        }

        // GET: Medical_equipment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical_equipment = await _context.medical_Equipment
                .Include(m => m.Department)
                .FirstOrDefaultAsync(m => m.Equipment_Id == id);
            if (medical_equipment == null)
            {
                return NotFound();
            }

            return View(medical_equipment);
        }

        // GET: Medical_equipment/Create
        public IActionResult Create()
        {
            ViewData["Dnum"] = new SelectList(_context.departments, "Dnum", "Dname");
            return View();
        }

        // POST: Medical_equipment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Equipment_Id,Equip_name,Maintence_date,IsDeleted,Dnum")] Medical_equipment medical_equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medical_equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Dnum"] = new SelectList(_context.departments, "Dnum", "Dname", medical_equipment.Dnum);
            return View(medical_equipment);
        }

        // GET: Medical_equipment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical_equipment = await _context.medical_Equipment.FindAsync(id);
            if (medical_equipment == null)
            {
                return NotFound();
            }
            ViewData["Dnum"] = new SelectList(_context.departments, "Dnum", "Dname", medical_equipment.Dnum);
            return View(medical_equipment);
        }

        // POST: Medical_equipment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Equipment_Id,Equip_name,Maintence_date,IsDeleted,Dnum")] Medical_equipment medical_equipment)
        {
            if (id != medical_equipment.Equipment_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medical_equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Medical_equipmentExists(medical_equipment.Equipment_Id))
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
            ViewData["Dnum"] = new SelectList(_context.departments, "Dnum", "Dname", medical_equipment.Dnum);
            return View(medical_equipment);
        }

        // GET: Medical_equipment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical_equipment = await _context.medical_Equipment
                .Include(m => m.Department)
                .FirstOrDefaultAsync(m => m.Equipment_Id == id);
            if (medical_equipment == null)
            {
                return NotFound();
            }

            return View(medical_equipment);
        }

        // POST: Medical_equipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medical_equipment = await _context.medical_Equipment.FindAsync(id);
            if (medical_equipment != null)
            {
                _context.medical_Equipment.Remove(medical_equipment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Medical_equipmentExists(int id)
        {
            return _context.medical_Equipment.Any(e => e.Equipment_Id == id);
        }
    }
}
