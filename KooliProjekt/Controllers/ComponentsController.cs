using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KooliProjekt.Data;
using KooliProjekt.Services;

namespace KooliProjekt.Controllers
{
    public class ComponentsController : Controller
    {
        private readonly IComponentService _componentService;

        // Внедрение зависимости через конструктор
        public ComponentsController(IComponentService componentService)
        {
            _componentService = componentService;
        }

        // GET: Components
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _componentService.GetPagedAsync(page, 5);  // Используем сервис для пагинации
            return View(data);
        }

        // GET: Components/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _componentService.GetByIdAsync(id.Value);  // Используем сервис
            if (component == null)
            {
                return NotFound();
            }

            return View(component);
        }

        // GET: Components/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Components/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UnitPrice")] Component component)
        {
            if (ModelState.IsValid)
            {
                await _componentService.AddAsync(component);  // Используем сервис
                return RedirectToAction(nameof(Index));
            }
            return View(component);
        }

        // GET: Components/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _componentService.GetByIdAsync(id.Value);  // Используем сервис
            if (component == null)
            {
                return NotFound();
            }
            return View(component);
        }

        // POST: Components/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,UnitPrice")] Component component)
        {
            if (id != component.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _componentService.UpdateAsync(component);  // Используем сервис
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    if (await _componentService.GetByIdAsync(component.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(component);
        }

        // GET: Components/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _componentService.GetByIdAsync(id.Value);  // Используем сервис
            if (component == null)
            {
                return NotFound();
            }

            return View(component);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _componentService.DeleteAsync(id);  // Используем сервис для удаления
            return RedirectToAction(nameof(Index));
        }
    }
}
