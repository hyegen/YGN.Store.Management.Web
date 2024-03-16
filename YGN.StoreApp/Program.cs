using Microsoft.EntityFrameworkCore;
using YGN.Services.Concrete;
using YGN.Services.Contracts;
using YGN.Services.Contracts.Manager;
using YGN.StoreApp.Entities.Models;
using YGN.StoreApp.Models;
using YGN.StoreApp.Repositories;
using YGN.StoreApp.Repositories.Concrete;
using YGN.StoreApp.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
        b => b.MigrationsAssembly("YGN.StoreApp"));
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "YGN.Store.App.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<Cart>(x => SessionCart.GetCart(x));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles(); //wwwroot
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
        );
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.UseAuthorization();

app.Run();

//app.UseHttpsRedirection();
//app.UseStaticFiles(); //wwwroot

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapAreaControllerRoute(
//        name: "Admin",
//        areaName: "Admin",
//        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
//        );
//    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
//});

//app.UseAuthorization();

//app.UseRouting();

//app.Run();
