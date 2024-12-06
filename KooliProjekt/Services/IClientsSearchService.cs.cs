using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Services
{
    public interface IClientsSearchService
    {
        Task<PagedResult<Structure>> List(int page, int pageSize, ClientsSearch query = null);
        Task<Structure> Get(int id);
        Task Save(Client list);
        Task Delete(int id);
    }
}