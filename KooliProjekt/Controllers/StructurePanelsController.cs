using KooliProjekt.Services;
using KooliProjekt.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.Controllers
{
    public class StructurePanelsController : Controller
    {
        private readonly IStructurePanelService _structurePanelService;

        // Внедрение сервиса через конструктор
        public StructurePanelsController(IStructurePanelService structurePanelService)
        {
            _structurePanelService = structurePanelService;
        }

        // GET: StructurePanels
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _structurePanelService.GetPagedAsync(page, 5);  // Используем сервис для пагинации
            return View(data);
        }

        // GET: StructurePanels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var structurePanel = await _structurePanelService.GetByIdAsync(id.Value);  // Используем сервис
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Structure_Ref,Amount")] StructurePanel structurePanel)
        {
            if (ModelState.IsValid)
            {
                await _structurePanelService.AddAsync(structurePanel);  // Используем сервис для добавления
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

            var structurePanel = await _structurePanelService.GetByIdAsync(id.Value);  // Используем сервис
            if (structurePanel == null)
            {
                return NotFound();
            }
            return View(structurePanel);
        }

        // POST: StructurePanels/Edit/5
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
                    await _structurePanelService.UpdateAsync(structurePanel);  // Используем сервис для обновления
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    if (await _structurePanelService.GetByIdAsync(structurePanel.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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

            var structurePanel = await _structurePanelService.GetByIdAsync(id.Value);  // Используем сервис
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
            await _structurePanelService.DeleteAsync(id);  // Используем сервис для удаления
            return RedirectToAction(nameof(Index));
        }
    }
}
