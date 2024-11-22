using KooliProjekt.Data;

public interface IClientService
{
    Task<IEnumerable<Client>> GetAllAsync();
    Task<PagedResult<Client>> List(int page, int pageSize);
    Task<Client?> GetByIdAsync(long id);
    Task AddAsync(Client client);
    Task UpdateAsync(Client client);
    Task DeleteAsync(long id);

    // Новый метод для удаления клиента и его связанных структур
    Task DeleteClientAndRelatedStructuresAsync(long clientId);
}
