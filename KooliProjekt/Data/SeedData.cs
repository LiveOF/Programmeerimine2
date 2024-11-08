using KooliProjekt.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public static class SeedData
{
    public static void Generate(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        // Проверяем, есть ли данные в базе
        if (context.Client.Any() || context.Component.Any() || context.Structure.Any() || context.Services.Any())
        {
            return; // Если данные есть, выходим из метода
        }

        // Создание пользователя
        var user = new IdentityUser
        {
            UserName = "newuser@example.com",
            Email = "newuser@example.com",
            NormalizedUserName = "NEWUSER@EXAMPLE.COM", // Рекомендуется для регистрация без учета регистра
            NormalizedEmail = "NEWUSER@EXAMPLE.COM"    // Рекомендуется для регистрация без учета регистра
        };

        // Создаем пользователя с паролем
        userManager.CreateAsync(user, "Password123!").Wait();

        // Создание данных для таблицы Material
        var material1 = new Component
        {
            Name = "Component 1",
            UnitPrice = 15.5m
        };
        context.Component.Add(material1);

        var material2 = new Component
        {
            Name = "Component 2",
            UnitPrice = 25.0m
        };
        context.Component.Add(material2);

        // Создание структуры (Building)
        var building1 = new Structure
        {
            Location = "Location 1",
            Date = DateTime.Now,
            Client = new Client { Name = "Client 1" }, // Пример клиента
        };
        context.Structure.Add(building1);

        // Создание структуры панели
        var structurePanel1 = new StructurePanel
        {
            Structure = building1,
            Amount = 5
        };
        context.StructurePanel.Add(structurePanel1);

        // Создание панели
        var panel1 = new PanelData
        {
            Dimensions = 100,
            UnitPrice = 20.5m,
            TotalPrice = 1025.0m
        };
        context.PanelData.Add(panel1);

        // Привязка компонентов (панелей) к структурам
        var panelComponent1 = new PanelComponent
        {
            Panel_Ref = 1,
            Amount = 2,
            Component = material1,
            PanelData = panel1
        };
        context.PanelComponent.Add(panelComponent1);

        // Пример услуги
        var service1 = new Services
        {
            Name = "Service 1",
            Price = 300m,
            Structure = building1
        };
        context.Services.Add(service1);

        // Сохранение изменений в базе данных
        try
        {
            context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.InnerException?.Message);
            Console.WriteLine(ex.InnerException?.StackTrace);
            throw; // Перекидываем исключение для дальнейшего анализа
        }

    }
}
