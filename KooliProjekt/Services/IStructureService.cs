using KooliProjekt.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public interface IStructureService
    {
        Task<IEnumerable<Structure>> GetAllAsync();  // Получить все структуры
        Task<Structure?> GetByIdAsync(long id);  // Получить структуру по ID
        Task AddAsync(Structure structure);  // Добавить структуру
        Task UpdateAsync(Structure structure);  // Обновить структуру
        Task DeleteAsync(long id);  // Удалить структуру
        Task<PagedResult<Structure>> GetPagedAsync(int page, int pageSize);  // Пагинация для структур
    }
}
