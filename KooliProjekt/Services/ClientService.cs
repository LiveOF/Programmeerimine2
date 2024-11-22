using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;

    public ClientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Client.ToListAsync();
    }

    public async Task<PagedResult<Client>> List(int page, int pageSize)
    {
        return await _context.Client.GetPagedAsync(page, pageSize);
    }

    public async Task<Client?> GetByIdAsync(long id)
    {
        return await _context.Client.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Client client)
    {
        _context.Client.Add(client);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Client client)
    {
        _context.Client.Update(client);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var client = await _context.Client.FindAsync(id);
        if (client != null)
        {
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
        }
    }

    // Новый метод для удаления клиента и всех связанных с ним данных
    public async Task DeleteClientAndRelatedStructuresAsync(long clientId)
    {
        var client = await _context.Client
            .Include(c => c.Structure)  // Включаем связанные структуры
            .FirstOrDefaultAsync(c => c.Id == clientId);

        if (client != null)
        {
            // Удаляем все связанные структуры
            foreach (var structure in client.Structure.ToList())  // ToList() для безопасного удаления
            {
                _context.Structure.Remove(structure);
            }

            // Удаляем клиента
            _context.Client.Remove(client);

            // Сохраняем изменения в базе данных
            await _context.SaveChangesAsync();
        }
    }
}
