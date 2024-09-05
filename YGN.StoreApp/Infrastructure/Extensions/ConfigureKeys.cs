using Microsoft.AspNetCore.DataProtection;

namespace YGN.StoreApp.Infrastructure.Extensions
{
    public class ConfigureKeys
    {
        private readonly IWebHostEnvironment _env;

        public ConfigureKeys(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var keysPath = Path.Combine(_env.ContentRootPath, "Keys");
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(keysPath))
                .SetApplicationName("MyApp");

            services.AddControllersWithViews();
        }
    }
}
