using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ApplicationDbContext _context;

        public ServiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KooliProjekt.Data.Services>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();  // Получаем все Services
        }

        public async Task<KooliProjekt.Data.Services?> GetByIdAsync(long id)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.Id == id);  // Получаем Service по ID
        }

        public async Task AddAsync(KooliProjekt.Data.Services services)
        {
            _context.Services.Add(services);  // Добавляем Service
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(KooliProjekt.Data.Services services)
        {
            _context.Services.Update(services);  // Обновляем Service
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var services = await _context.Services.FindAsync(id);  // Находим Service по ID
            if (services != null)
            {
                _context.Services.Remove(services);  // Удаляем Service
                await _context.SaveChangesAsync();
            }
        }

        // Метод для пагинации
        public async Task<PagedResult<KooliProjekt.Data.Services>> GetPagedAsync(int page, int pageSize)
        {
            page = Math.Max(page, 1);
            if (pageSize == 0)
            {
                pageSize = 10;
            }

            var result = new PagedResult<KooliProjekt.Data.Services>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = await _context.Services.CountAsync()  // Получаем количество Services
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await _context.Services.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
