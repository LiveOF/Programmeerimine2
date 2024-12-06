using KooliProjekt.Data;
using KooliProjekt.Search;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class StructureSearchService : IStructureSearchService
    {
        private readonly ApplicationDbContext _context;

        public StructureSearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            await _context.Structure
                .Where(list => list.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<Structure> Get(int id)
        {
            return await _context.Structure.FindAsync(id);
        }

        public async Task<PagedResult<Structure>> List(int page, int pageSize, StructureSearch search = null)
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

        public async Task Save(Structure list)
        {
            if(list.Id == 0)
            {
                _context.Structure.Add(list);
            }
            else
            {
                _context.Structure.Update(list);
            }

            await _context.SaveChangesAsync();
        }
    }
}
