using KooliProjekt.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public interface IStructurePanelService
    {
        Task<IEnumerable<StructurePanel>> GetAllAsync();  // Получить все StructurePanels
        Task<StructurePanel?> GetByIdAsync(long id);  // Получить StructurePanel по ID
        Task AddAsync(StructurePanel structurePanel);  // Добавить StructurePanel
        Task UpdateAsync(StructurePanel structurePanel);  // Обновить StructurePanel
        Task DeleteAsync(long id);  // Удалить StructurePanel
        Task<PagedResult<StructurePanel>> GetPagedAsync(int page, int pageSize);  // Пагинация для StructurePanel
    }
}
