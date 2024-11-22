using KooliProjekt.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public interface IPanelDataService
    {
        Task<IEnumerable<PanelData>> GetAllAsync();  // Получить все PanelData
        Task<PanelData?> GetByIdAsync(long id);  // Получить PanelData по ID
        Task AddAsync(PanelData panelData);  // Добавить PanelData
        Task UpdateAsync(PanelData panelData);  // Обновить PanelData
        Task DeleteAsync(long id);  // Удалить PanelData
        Task<PagedResult<PanelData>> GetPagedAsync(int page, int pageSize);  // Пагинация для PanelData
    }
}
