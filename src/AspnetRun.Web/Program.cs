using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Services;
using AspnetRun.Core.Configuration;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Repositories.Base;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository;
using AspnetRun.Infrastructure.Repository.Base;
using AspnetRun.Web.Data.Interfaces;
using AspnetRun.Web.Data.Services;
using AspnetRun.Web.HealthChecks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

builder.Services.Configure<AspnetRunSettings>(configuration);
builder.Services.AddDbContext<AspnetRunContext>(c =>
    c.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                   x => x.MigrationsAssembly("AspnetRun.Web")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AspnetRunContext>();
builder.Services.AddRazorPages();

builder.Services.AddLogging();

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Async(
        a => a.File("Logs/log.txt", 
                    rollingInterval: RollingInterval.Day, 
                    retainedFileCountLimit: 7,
                    buffered: true, 
                    flushToDiskInterval: TimeSpan.FromSeconds(5))
     )
    .WriteTo.Console()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

//
// cookie
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});


services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<ICategoryRepository, CategoryRepository>();
services.AddScoped<ICartRepository, CartRepository>();
services.AddScoped<IWishlistRepository, WishlistRepository>();
services.AddScoped<ICompareRepository, CompareRepository>();
services.AddScoped<IOrderRepository, OrderRepository>();

services.AddScoped<IProductService, ProductService>();
services.AddScoped<ICategoryService, CategoryService>();
services.AddScoped<ICartService, CartService>();
services.AddScoped<IWishlistService, WishListService>();
services.AddScoped<ICompareService, CompareService>();
services.AddScoped<IOrderService, OrderService>();

services.AddScoped<IIndexPageService, IndexPageService>();
services.AddScoped<IProductPageService, ProductPageService>();
services.AddScoped<ICategoryPageService, CategoryPageService>();
services.AddScoped<ICartComponentService, CartComponentService>();
services.AddScoped<IWishlistPageService, WishlistPageService>();
services.AddScoped<IComparePageService, ComparePageService>();
services.AddScoped<ICheckOutPageService, CheckOutPageService>();

services.AddAutoMapper(typeof(Program));
services.AddHttpContextAccessor();
services.AddHealthChecks().AddCheck<IndexPageHealthCheck>("home_page_health_check");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

// app.UseSerilogRequestLogging();

// seed data
using (var scope = app.Services.CreateScope())
{
    var svc = scope.ServiceProvider;
    var loggerFactory = svc.GetRequiredService<ILoggerFactory>();

    try
    {
        var aspnetRunContext = svc.GetRequiredService<AspnetRunContext>();
        AspnetRunContextSeed.SeedAsync(aspnetRunContext, loggerFactory).Wait();
    }
    catch (Exception exception)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(exception, "An error occurred seeding the DB.");
    }
}

app.Run();