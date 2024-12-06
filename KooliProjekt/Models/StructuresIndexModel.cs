using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Models
{
    public class StructuresIndexModel
    {
        public StructureSearch Search { get; set; }
        public PagedResult<Structure> Data { get; set; }
    }
}
