using KooliProjekt.Data;
using KooliProjekt.Search;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class TodoListService : IClientsSearchService
    {
        private readonly ApplicationDbContext _context;

        public TodoListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            await _context.Client
                .Where(list => list.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<Client> Get(int id)
        {
            return await _context.Client.FindAsync(id);
        }

        public async Task<PagedResult<Client>> List(int page, int pageSize, ClientsSearch search = null)
        {
            var query = _context.Client.AsQueryable();

            search = search ?? new ClientsSearch();

            if (!string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(list => list.Name.Contains(search.Keyword));
            }

            return await query
                .OrderBy(list => list.Name)
                .GetPagedAsync(page, pageSize);
        }

        public async Task Save(Client list)
        {
            if (list.Id == 0)
            {
                _context.Client.Add(list);
            }
            else
            {
                _context.Client.Update(list);
            }

            await _context.SaveChangesAsync();
        }
    }
}
