using KooliProjekt.Services;
using KooliProjekt.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.Controllers
{
    public class PanelDatasController : Controller
    {
        private readonly IPanelDataService _panelDataService;

        // Внедрение сервиса через конструктор
        public PanelDatasController(IPanelDataService panelDataService)
        {
            _panelDataService = panelDataService;
        }

        // GET: PanelDatas
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _panelDataService.GetPagedAsync(page, 5);  // Используем сервис для пагинации
            return View(data);
        }

        // GET: PanelDatas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panelData = await _panelDataService.GetByIdAsync(id.Value);  // Используем сервис
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dimensions,UnitPrice,TotalPrice")] PanelData panelData)
        {
            if (ModelState.IsValid)
            {
                await _panelDataService.AddAsync(panelData);  // Используем сервис для добавления
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

            var panelData = await _panelDataService.GetByIdAsync(id.Value);  // Используем сервис
            if (panelData == null)
            {
                return NotFound();
            }
            return View(panelData);
        }

        // POST: PanelDatas/Edit/5
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
                    await _panelDataService.UpdateAsync(panelData);  // Используем сервис для обновления
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    if (await _panelDataService.GetByIdAsync(panelData.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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

            var panelData = await _panelDataService.GetByIdAsync(id.Value);  // Используем сервис
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
            await _panelDataService.DeleteAsync(id);  // Используем сервис для удаления
            return RedirectToAction(nameof(Index));
        }
    }
}
