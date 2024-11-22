using KooliProjekt.Services;
using KooliProjekt.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceService _serviceService;

        // Внедрение сервиса через конструктор
        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: Services
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _serviceService.GetPagedAsync(page, 5);  // Используем сервис для пагинации
            return View(data);
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _serviceService.GetByIdAsync(id.Value);  // Используем сервис
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Structure_Ref,Price,Name")] KooliProjekt.Data.Services services)
        {
            if (ModelState.IsValid)
            {
                await _serviceService.AddAsync(services);  // Используем сервис для добавления
                return RedirectToAction(nameof(Index));
            }
            return View(services);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _serviceService.GetByIdAsync(id.Value);  // Используем сервис
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }

        // POST: Services/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Structure_Ref,Price,Name")] KooliProjekt.Data.Services services)
        {
            if (id != services.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceService.UpdateAsync(services);  // Используем сервис для обновления
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    if (await _serviceService.GetByIdAsync(services.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(services);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _serviceService.GetByIdAsync(id.Value);  // Используем сервис
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _serviceService.DeleteAsync(id);  // Используем сервис для удаления
            return RedirectToAction(nameof(Index));
        }
    }
}
