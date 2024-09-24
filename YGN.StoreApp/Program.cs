using YGN.StoreApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.WithOrigins("94.138.198.15") // Belirli bir IP adresi veya domain
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

// Data Protection API yapýlandýrmasý
//var keysPath = Path.Combine(builder.Environment.ContentRootPath, "Keys");
//builder.Services.AddDataProtection()
//    .PersistKeysToFileSystem(new DirectoryInfo(keysPath))
//    .SetApplicationName("MyApp");

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseCors("AllowAll");

app.UseStaticFiles(); // wwwroot
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseDeveloperExceptionPage();

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

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.Run();
