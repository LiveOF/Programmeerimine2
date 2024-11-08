using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;

namespace KooliProjekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<KooliProjekt.Data.Client> Client { get; set; } = default!;
        public DbSet<KooliProjekt.Data.Component> Component { get; set; } = default!;
        public DbSet<KooliProjekt.Data.PanelComponent> PanelComponent { get; set; } = default!;
        public DbSet<KooliProjekt.Data.PanelData> PanelData { get; set; } = default!;
        public DbSet<KooliProjekt.Data.Services> Services { get; set; } = default!;
        public DbSet<KooliProjekt.Data.Structure> Structure { get; set; } = default!;
        public DbSet<KooliProjekt.Data.StructurePanel> StructurePanel { get; set; } = default!;
    }
}