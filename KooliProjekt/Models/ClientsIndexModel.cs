using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Models
{
    public class ClientsIndexModel
    {
        public StructureSearch Search { get; set; }
        public PagedResult<Structure> Data { get; set; }
    }
}
