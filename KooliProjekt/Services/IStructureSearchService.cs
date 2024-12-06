using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Services
{
    public interface IStructureSearchService
    {
        Task<PagedResult<Structure>> List(int page, int pageSize, StructureSearch query = null);
        Task<Structure> Get(int id);
        Task Save(Structure list);
        Task Delete(int id);    
    }
}