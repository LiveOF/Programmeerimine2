using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public class ComponentService : IComponentService
    {
        private readonly ApplicationDbContext _context;

        public ComponentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Component>> GetAllAsync()
        {
            return await _context.Component.ToListAsync();
        }

        public async Task<Component?> GetByIdAsync(long id)
        {
            return await _context.Component.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Component component)
        {
            _context.Component.Add(component);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Component component)
        {
            _context.Component.Update(component);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var component = await _context.Component.FindAsync(id);
            if (component != null)
            {
                _context.Component.Remove(component);
                await _context.SaveChangesAsync();
            }
        }

        // Реализация метода для пагинации
        public async Task<PagedResult<Component>> GetPagedAsync(int page, int pageSize)
        {
            page = Math.Max(page, 1);
            if (pageSize == 0)
            {
                pageSize = 10;
            }

            var result = new PagedResult<Component>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = await _context.Component.CountAsync()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await _context.Component.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
