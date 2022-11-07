using SalesApp.Models;
using SalesApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder);

var app = builder.Build();

//await CreateAndSeedDatabase(app);

// Configure the HTTP request pipeline.

ConfigureMiddlewarePipeline(app);

app.Run();

static void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.Configure<ApiUrls>(builder.Configuration.GetSection(ApiUrls.API_URL_SECTION));
    //builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
    builder.Services.AddSingleton<IProductHttpService, ProductHttpService>();
    //builder.Services.AddAutoMapper(typeof(ProductModelToProduct));
    //var conStr = builder.Configuration.GetConnectionString("SalesAppDb");
    //builder.Services.AddDbContext<SalesAppDbcontext>(
    //    options =>
    //    {
    //        options.UseSqlServer(conStr);
    //    });
    builder.Services.AddControllersWithViews();
    //builder.Services.AddRazorPages();
    builder.Services.AddHttpClient();
}

static void ConfigureMiddlewarePipeline(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action}/{id?}",
        defaults: new { controller = "Home", action = "Index" }
        );
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