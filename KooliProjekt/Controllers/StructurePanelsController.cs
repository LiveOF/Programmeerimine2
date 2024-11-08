using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;

namespace KooliProjekt.Controllers
{
    public class StructurePanelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StructurePanelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StructurePanels
        public async Task<IActionResult> Index()
        {
            return View(await _context.StructurePanel.ToListAsync());
        }

        // GET: StructurePanels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structurePanel = await _context.StructurePanel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (structurePanel == null)
            {
                return NotFound();
            }

            return View(structurePanel);
        }

        // GET: StructurePanels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StructurePanels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Structure_Ref,Amount")] StructurePanel structurePanel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(structurePanel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(structurePanel);
        }

        // GET: StructurePanels/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structurePanel = await _context.StructurePanel.FindAsync(id);
            if (structurePanel == null)
            {
                return NotFound();
            }
            return View(structurePanel);
        }

        // POST: StructurePanels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Structure_Ref,Amount")] StructurePanel structurePanel)
        {
            if (id != structurePanel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(structurePanel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StructurePanelExists(structurePanel.Id))
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
            return View(structurePanel);
        }

        // GET: StructurePanels/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structurePanel = await _context.StructurePanel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (structurePanel == null)
            {
                return NotFound();
            }

            return View(structurePanel);
        }

        // POST: StructurePanels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var structurePanel = await _context.StructurePanel.FindAsync(id);
            if (structurePanel != null)
            {
                _context.StructurePanel.Remove(structurePanel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StructurePanelExists(long id)
        {
            return _context.StructurePanel.Any(e => e.Id == id);
        }
    }
}
