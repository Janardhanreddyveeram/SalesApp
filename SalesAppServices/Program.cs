using Microsoft.EntityFrameworkCore;
using SalesApp.Core.Repositories;
using SalesAppData.Data;
using SalesAppData.Repositories;
using SalesAppData.Repositories.Base;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureAPIServices(builder);

var app = builder.Build();

//await CreateAndSeedDatabase(app);

ConfigureAPIMiddlewarePipeline(app);

app.Run();

static void ConfigureAPIServices(WebApplicationBuilder builder)
{

    //builder.Services.AddDbContext<SalesAppDbcontext>(options => options.UseSqlServer(
    //    builder.Configuration.GetConnectionString("SalesAppDb")
    //));

    var conStr = builder.Configuration.GetConnectionString("SalesAppDb");
    builder.Services.AddDbContext<SalesAppDbcontext>(
        options =>
        {
            options.EnableSensitiveDataLogging();
            options.UseSqlServer(conStr);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    //builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

static void ConfigureAPIMiddlewarePipeline(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

//static async Task CreateAndSeedDatabase(WebApplication app)
//{
//    var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
//    try
//    {
//        var serviceProvider = app.Services.GetRequiredService<IServiceProvider>();
//        using (var scope = serviceProvider.CreateScope())
//        {
//            var dbContext = scope.ServiceProvider.GetRequiredService<SalesAppDbcontext>();
//            await SalesAppDbSeed.SeedAsync(dbContext, loggerFactory, 3);
//        }
//    }
//    catch (Exception ex)
//    {
//        var logger = loggerFactory.CreateLogger("Application");
//        logger.LogError(ex.Message);
//        throw;
//    }
//}