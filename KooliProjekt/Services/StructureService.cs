using KooliProjekt.Data;
using KooliProjekt.Search;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public class StructureService : IStructureService
    {
        private readonly ApplicationDbContext _context;

        public StructureService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Structure>> List(int page, int pageSize, StructureSearch search)
        {
            var query = _context.Structure.AsQueryable();

            search = search ?? new StructureSearch();

            if (!string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(list => list.Location.Contains(search.Keyword));
            }
            return await query
                .OrderBy(list => list.Location)
                .GetPagedAsync(page, pageSize);
        }

        public async Task<IEnumerable<Structure>> GetAllAsync()
        {
            return await _context.Structure.ToListAsync();  // Получаем все структуры
        }

        public async Task<Structure?> GetByIdAsync(long id)
        {
            return await _context.Structure.FirstOrDefaultAsync(s => s.Id == id);  // Получаем структуру по ID
        }

        public async Task AddAsync(Structure structure)
        {
            _context.Structure.Add(structure);  // Добавляем структуру
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Structure structure)
        {
            _context.Structure.Update(structure);  // Обновляем структуру
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var structure = await _context.Structure.FindAsync(id);  // Находим структуру по ID
            if (structure != null)
            {
                _context.Structure.Remove(structure);  // Удаляем структуру
                await _context.SaveChangesAsync();
            }
        }

        // Метод для пагинации
        public async Task<PagedResult<Structure>> GetPagedAsync(int page, int pageSize)
        {
            page = Math.Max(page, 1);
            if (pageSize == 0)
            {
                pageSize = 10;
            }

            var result = new PagedResult<Structure>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = await _context.Structure.CountAsync()  // Получаем количество структур
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await _context.Structure.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
