using KooliProjekt.Data;  // Подключаем пространство имен для класса Services

namespace KooliProjekt.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<KooliProjekt.Data.Services>> GetAllAsync();  // Получить все Services
        Task<KooliProjekt.Data.Services?> GetByIdAsync(long id);  // Получить Service по ID
        Task AddAsync(KooliProjekt.Data.Services services);  // Добавить Service
        Task UpdateAsync(KooliProjekt.Data.Services services);  // Обновить Service
        Task DeleteAsync(long id);  // Удалить Service
        Task<PagedResult<KooliProjekt.Data.Services>> GetPagedAsync(int page, int pageSize);  // Пагинация для Services
    }
}
