using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public class PanelDataService : IPanelDataService
    {
        private readonly ApplicationDbContext _context;

        public PanelDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PanelData>> GetAllAsync()
        {
            return await _context.PanelData.ToListAsync();  // Получаем все PanelData
        }

        public async Task<PanelData?> GetByIdAsync(long id)
        {
            return await _context.PanelData.FirstOrDefaultAsync(pd => pd.Id == id);  // Получаем PanelData по ID
        }

        public async Task AddAsync(PanelData panelData)
        {
            _context.PanelData.Add(panelData);  // Добавляем PanelData
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PanelData panelData)
        {
            _context.PanelData.Update(panelData);  // Обновляем PanelData
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var panelData = await _context.PanelData.FindAsync(id);  // Находим по ID
            if (panelData != null)
            {
                _context.PanelData.Remove(panelData);  // Удаляем PanelData
                await _context.SaveChangesAsync();
            }
        }

        // Метод для пагинации
        public async Task<PagedResult<PanelData>> GetPagedAsync(int page, int pageSize)
        {
            page = Math.Max(page, 1);
            if (pageSize == 0)
            {
                pageSize = 10;
            }

            var result = new PagedResult<PanelData>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = await _context.PanelData.CountAsync()  // Получаем количество PanelData
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await _context.PanelData.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
