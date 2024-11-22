using KooliProjekt.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public interface IComponentService
    {
        Task<IEnumerable<Component>> GetAllAsync();  // Получить все компоненты
        Task<Component?> GetByIdAsync(long id);  // Получить компонент по ID
        Task AddAsync(Component component);  // Добавить новый компонент
        Task UpdateAsync(Component component);  // Обновить компонент
        Task DeleteAsync(long id);  // Удалить компонент
        Task<PagedResult<Component>> GetPagedAsync(int page, int pageSize);  // Пагинация для компонентов
    }
}
