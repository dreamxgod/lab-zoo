using Microsoft.EntityFrameworkCore;
using ZooShop.Logic;

var builder = WebApplication.CreateBuilder(args);

// Налаштування логування
builder.Logging.ClearProviders();  // Очистити попередні логери, якщо є
builder.Logging.AddConsole();  // Додати логування в консоль

// Логування початку програми
builder.Logging.AddDebug();
builder.Logging.AddFilter("Microsoft.AspNetCore.Routing", LogLevel.Debug);

// Налаштування DbContext для SQLite
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlite("Data Source=database.db"));

// Налаштування MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Логування інформації при запуску програми
app.Logger.LogInformation("Application is starting up...");

app.UseRouting();
// Налаштування маршрутизації
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
// });

app.Logger.LogInformation("Routing is set up to 'Home/Index' by default.");

// Перевірка наявності БД та її створення
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    dbContext.Database.EnsureCreated();
    app.Logger.LogInformation("Database check and creation complete.");
}

app.Run();