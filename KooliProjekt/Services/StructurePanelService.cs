using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public class StructurePanelService : IStructurePanelService
    {
        private readonly ApplicationDbContext _context;

        public StructurePanelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StructurePanel>> GetAllAsync()
        {
            return await _context.StructurePanel.ToListAsync();  // Получаем все StructurePanels
        }

        public async Task<StructurePanel?> GetByIdAsync(long id)
        {
            return await _context.StructurePanel.FirstOrDefaultAsync(sp => sp.Id == id);  // Получаем StructurePanel по ID
        }

        public async Task AddAsync(StructurePanel structurePanel)
        {
            _context.StructurePanel.Add(structurePanel);  // Добавляем StructurePanel
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StructurePanel structurePanel)
        {
            _context.StructurePanel.Update(structurePanel);  // Обновляем StructurePanel
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var structurePanel = await _context.StructurePanel.FindAsync(id);  // Находим по ID
            if (structurePanel != null)
            {
                _context.StructurePanel.Remove(structurePanel);  // Удаляем StructurePanel
                await _context.SaveChangesAsync();
            }
        }

        // Метод для пагинации
        public async Task<PagedResult<StructurePanel>> GetPagedAsync(int page, int pageSize)
        {
            page = Math.Max(page, 1);
            if (pageSize == 0)
            {
                pageSize = 10;
            }

            var result = new PagedResult<StructurePanel>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = await _context.StructurePanel.CountAsync()  // Получаем количество StructurePanels
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await _context.StructurePanel.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
