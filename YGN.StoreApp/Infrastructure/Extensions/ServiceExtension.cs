using Microsoft.EntityFrameworkCore;
using YGN.Services.Concrete;
using YGN.Services.Contracts.Manager;
using YGN.Services.Contracts;
using YGN.StoreApp.Repositories;
using YGN.StoreApp.Repositories.Concrete;
using YGN.StoreApp.Repositories.Contracts;
using YGN.StoreApp.Entities.Models;
using YGN.StoreApp.Models;

namespace YGN.StoreApp.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("sqlconnection"),
                    b => b.MigrationsAssembly("YGN.StoreApp"));
            });
        }
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "YGN.Store.App.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(5);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(x => SessionCart.GetCart(x));
        }
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IOrderService, OrderManager>();
        }
    }
}
