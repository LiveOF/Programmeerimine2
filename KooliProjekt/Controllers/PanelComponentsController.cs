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
    public class PanelComponentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PanelComponentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PanelComponents
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _context.PanelComponent.GetPagedAsync(page, 5);
            return View(data);

        }

        // GET: PanelComponents/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelComponent = await _context.PanelComponent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panelComponent == null)
            {
                return NotFound();
            }

            return View(panelComponent);
        }

        // GET: PanelComponents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PanelComponents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Panel_Ref,Amount")] PanelComponent panelComponent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(panelComponent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(panelComponent);
        }

        // GET: PanelComponents/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelComponent = await _context.PanelComponent.FindAsync(id);
            if (panelComponent == null)
            {
                return NotFound();
            }
            return View(panelComponent);
        }

        // POST: PanelComponents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Panel_Ref,Amount")] PanelComponent panelComponent)
        {
            if (id != panelComponent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(panelComponent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PanelComponentExists(panelComponent.Id))
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
            return View(panelComponent);
        }

        // GET: PanelComponents/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelComponent = await _context.PanelComponent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panelComponent == null)
            {
                return NotFound();
            }

            return View(panelComponent);
        }

        // POST: PanelComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var panelComponent = await _context.PanelComponent.FindAsync(id);
            if (panelComponent != null)
            {
                _context.PanelComponent.Remove(panelComponent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PanelComponentExists(long id)
        {
            return _context.PanelComponent.Any(e => e.Id == id);
        }
    }
}
