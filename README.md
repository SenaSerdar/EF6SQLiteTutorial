# EF6SQLiteTutorial

dotnet run edildiğinde Unhandled exception. System.InvalidOperationException: Cannot modify ServiceCollection after application is built. Hatası alıyordu
Çözüm :
builder.Services.AddDbContext<DataContext>(options=>options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("EF6SQLite")));
satırı v altına alındı.
using EF6SQLite.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options=>options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("EF6SQLite")));
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

