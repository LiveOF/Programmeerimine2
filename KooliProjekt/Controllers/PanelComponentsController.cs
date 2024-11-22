using KooliProjekt.Data;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.Controllers
{
    public class PanelComponentsController : Controller
    {
        private readonly IPanelComponentService _panelComponentService;

        // Внедрение сервиса через конструктор
        public PanelComponentsController(IPanelComponentService panelComponentService)
        {
            _panelComponentService = panelComponentService;
        }

        // GET: PanelComponents
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _panelComponentService.GetPagedAsync(page, 5);  // Используем сервис для пагинации
            return View(data);
        }

        // GET: PanelComponents/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelComponent = await _panelComponentService.GetByIdAsync(id.Value);  // Используем сервис
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Panel_Ref,Amount")] PanelComponent panelComponent)
        {
            if (ModelState.IsValid)
            {
                await _panelComponentService.AddAsync(panelComponent);  // Используем сервис
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

            var panelComponent = await _panelComponentService.GetByIdAsync(id.Value);  // Используем сервис
            if (panelComponent == null)
            {
                return NotFound();
            }
            return View(panelComponent);
        }

        // POST: PanelComponents/Edit/5
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
                    await _panelComponentService.UpdateAsync(panelComponent);  // Используем сервис
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    if (await _panelComponentService.GetByIdAsync(panelComponent.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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

            var panelComponent = await _panelComponentService.GetByIdAsync(id.Value);  // Используем сервис
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
            await _panelComponentService.DeleteAsync(id);  // Используем сервис для удаления
            return RedirectToAction(nameof(Index));
        }
    }
}
