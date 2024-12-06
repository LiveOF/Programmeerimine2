using KooliProjekt.Data;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Получаем строку подключения
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IComponentService, ComponentService>();
            builder.Services.AddScoped<IPanelDataService, PanelDataService>();
            builder.Services.AddScoped<IStructureService, StructureService>();
            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<IStructurePanelService, StructurePanelService>();
            builder.Services.AddScoped<IPanelComponentService, PanelComponentService>();
            builder.Services.AddScoped<IStructureSearchService, StructureSearchService>();



            var app = builder.Build();

            // Конфигурация для режима разработки
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();

                // Добавляем вызов метода SeedData.Generate только в режиме отладки
                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                    // Выполним миграции и добавим тестовые данные в базу
                    dbContext.Database.Migrate();
                    SeedData.Generate(dbContext, userManager);
                }
            }
            else
            {
                // Для продакшн-среды
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

#if DEBUG
            using (var scope = app.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
            using (var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>())
            {                                
                context.Database.EnsureCreated();
                SeedData.Generate(context, userManager);
            }
#endif

            app.Run();
        }
    }
}
