using Application.Utils;
using Microsoft.EntityFrameworkCore;
using Persistances.Common;
using Persistances.Data;
using Serilog;

namespace Endpoint.Api;

public static class StartupTasks
{
    public static async Task Init (WebApplication app, IConfiguration configuration)
    {
      
        var serviceProvider = app.Services;
        StartLogger (serviceProvider);
        VerifyDatabaseConnection (serviceProvider, configuration);
        MigrateDatabase (serviceProvider);
        await Seeder ( serviceProvider,10);
    }

    private static async Task Seeder (IServiceProvider serviceProvider,int CountforSeed)
    {
        using var scope = serviceProvider.CreateScope ();
        var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder> ();
        await dataSeeder.SeddProduct (CountforSeed);
        Log.Information ("Seed Data in Database");

    }

    private static void MigrateDatabase (IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope ();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext> ();
        dbContext.Database.Migrate(); 
    }

    private static void VerifyDatabaseConnection (IServiceProvider serviceProvider, IConfiguration configuration)
    {
        using var scope = serviceProvider.CreateScope ();
        var dbVerifier = scope.ServiceProvider.GetRequiredService<DatabaseConnectionVerifier> ();
        dbVerifier.IsServerConnected (configuration["ConnectionStrings:Default"]); 
    }

    private static void StartLogger (IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope ();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>> ();
        logger.Log (LogLevel.Critical, "User Ms started at: {Date}", nameof(StartLogger), DateTime.UtcNow);
    }
}