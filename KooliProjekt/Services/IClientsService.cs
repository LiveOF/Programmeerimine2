using KooliProjekt.Data;
using KooliProjekt.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public interface IClientsService
    {
        Task<IEnumerable<Client>> GetAllAsync();  // Получить все структуры
        Task<PagedResult<Client>> List(int page, int pageSize, ClientsSearch search);
        Task<Client?> GetByIdAsync(long id);  // Получить структуру по ID
        Task AddAsync(Client structure);  // Добавить структуру
        Task UpdateAsync(Client structure);  // Обновить структуру
        Task DeleteAsync(long id);  // Удалить структуру
        Task DeleteClientAndRelatedStructuresAsync(long clientId);
    }
}

