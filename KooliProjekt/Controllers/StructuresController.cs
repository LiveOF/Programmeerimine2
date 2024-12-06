using KooliProjekt.Services;
using KooliProjekt.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KooliProjekt.Models;

namespace KooliProjekt.Controllers
{
    public class StructuresController : Controller
    {
        private readonly IStructureService _structureService;

        // Внедрение сервиса через конструктор
        public StructuresController(IStructureService structureService)
        {
            _structureService = structureService;
        }

        // GET: Structures

        public async Task<IActionResult> Index(int page = 1, StructuresIndexModel model = null)
        {
            model = model ?? new StructuresIndexModel();
            model.Data = await _structureService.List(page, 5, model.Search);

            return View(model);
        }
        // GET: Structures/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structure = await _structureService.GetByIdAsync(id.Value);  // Используем сервис
            if (structure == null)
            {
                return NotFound();
            }

            return View(structure);
        }

        // GET: Structures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Structures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Client_Ref,Date,Location")] Structure structure)
        {
            if (ModelState.IsValid)
            {
                await _structureService.AddAsync(structure);  // Используем сервис для добавления
                return RedirectToAction(nameof(Index));
            }
            return View(structure);
        }

        // GET: Structures/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structure = await _structureService.GetByIdAsync(id.Value);  // Используем сервис
            if (structure == null)
            {
                return NotFound();
            }
            return View(structure);
        }

        // POST: Structures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Client_Ref,Date,Location")] Structure structure)
        {
            if (id != structure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _structureService.UpdateAsync(structure);  // Используем сервис для обновления
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    if (await _structureService.GetByIdAsync(structure.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(structure);
        }

        // GET: Structures/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structure = await _structureService.GetByIdAsync(id.Value);  // Используем сервис
            if (structure == null)
            {
                return NotFound();
            }

            return View(structure);
        }

        // POST: Structures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _structureService.DeleteAsync(id);  // Используем сервис для удаления
            return RedirectToAction(nameof(Index));
        }
    }
}
