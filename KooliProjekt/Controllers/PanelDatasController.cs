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
    public class PanelDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PanelDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PanelDatas
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _context.PanelData.GetPagedAsync(page, 5);
            return View(data);

        }

        // GET: PanelDatas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelData = await _context.PanelData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panelData == null)
            {
                return NotFound();
            }

            return View(panelData);
        }

        // GET: PanelDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PanelDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dimensions,UnitPrice,TotalPrice")] PanelData panelData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(panelData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(panelData);
        }

        // GET: PanelDatas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelData = await _context.PanelData.FindAsync(id);
            if (panelData == null)
            {
                return NotFound();
            }
            return View(panelData);
        }

        // POST: PanelDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Dimensions,UnitPrice,TotalPrice")] PanelData panelData)
        {
            if (id != panelData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(panelData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PanelDataExists(panelData.Id))
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
            return View(panelData);
        }

        // GET: PanelDatas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelData = await _context.PanelData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panelData == null)
            {
                return NotFound();
            }

            return View(panelData);
        }

        // POST: PanelDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var panelData = await _context.PanelData.FindAsync(id);
            if (panelData != null)
            {
                _context.PanelData.Remove(panelData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PanelDataExists(long id)
        {
            return _context.PanelData.Any(e => e.Id == id);
        }
    }
}
