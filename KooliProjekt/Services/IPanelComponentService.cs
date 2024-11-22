using KooliProjekt.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public interface IPanelComponentService
    {
        Task<IEnumerable<PanelComponent>> GetAllAsync();  // Получить все PanelComponent
        Task<PanelComponent?> GetByIdAsync(long id);  // Получить PanelComponent по ID
        Task AddAsync(PanelComponent panelComponent);  // Добавить новый PanelComponent
        Task UpdateAsync(PanelComponent panelComponent);  // Обновить существующий PanelComponent
        Task DeleteAsync(long id);  // Удалить PanelComponent
        Task<PagedResult<PanelComponent>> GetPagedAsync(int page, int pageSize);  // Пагинация PanelComponent
    }
}
