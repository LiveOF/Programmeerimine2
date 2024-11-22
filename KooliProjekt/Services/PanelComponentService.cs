using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public class PanelComponentService : IPanelComponentService
    {
        private readonly ApplicationDbContext _context;

        public PanelComponentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PanelComponent>> GetAllAsync()
        {
            return await _context.PanelComponent.ToListAsync();  // Получаем все PanelComponents
        }

        public async Task<PanelComponent?> GetByIdAsync(long id)
        {
            return await _context.PanelComponent.FirstOrDefaultAsync(pc => pc.Id == id);  // Получаем по ID
        }

        public async Task AddAsync(PanelComponent panelComponent)
        {
            _context.PanelComponent.Add(panelComponent);  // Добавляем PanelComponent
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PanelComponent panelComponent)
        {
            _context.PanelComponent.Update(panelComponent);  // Обновляем PanelComponent
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var panelComponent = await _context.PanelComponent.FindAsync(id);  // Находим по ID
            if (panelComponent != null)
            {
                _context.PanelComponent.Remove(panelComponent);  // Удаляем PanelComponent
                await _context.SaveChangesAsync();
            }
        }

        // Метод для пагинации
        public async Task<PagedResult<PanelComponent>> GetPagedAsync(int page, int pageSize)
        {
            page = Math.Max(page, 1);
            if (pageSize == 0)
            {
                pageSize = 10;
            }

            var result = new PagedResult<PanelComponent>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = await _context.PanelComponent.CountAsync()  // Получаем количество PanelComponents
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await _context.PanelComponent.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
