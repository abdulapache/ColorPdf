using Dataaccess.Entites;
using Dataaccess;
using Microsoft.EntityFrameworkCore;
using PersonalApp.Configuration;
using PersonalApp.Controllers;
using PersonalApp.Utilites;
using PersonalModel.Models;

public static class BackgroundTasks
{
    private static IServiceProvider _serviceProvider;

    public static void Initialize(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public static void StudentIndex()
    {
        var builder = WebApplication.CreateBuilder(new string[] { });
        var services = builder.Services;

        // Register required services
        services.AddDbContext<RestaurantContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDb")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IAppSettings, AppSettings>();
        services.AddTransient<ICookiesHelper, CookiesHelper>();

        var serviceProvider = services.BuildServiceProvider();
        var controller = new StudentController(
            serviceProvider.GetRequiredService<IAppSettings>(),
            serviceProvider.GetRequiredService<IUnitOfWork>(),
        serviceProvider.GetRequiredService<ICookiesHelper>(),
            serviceProvider.GetRequiredService<IConfiguration>()
        );

        // Call the Create action with the provided parameters
        controller.Index();
        //controller.Index(new Student { Name = name, Email = email });
    }
}
