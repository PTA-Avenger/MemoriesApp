using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MemoriesApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<MemoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSqlDb")));

// Add controllers, Razor pages, etc.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("AzureSqlDb")
                     ?? "Server=localhost;Database=FallbackDb;Trusted_Connection=True;";

builder.Services.AddDbContext<MemoryDbContext>(options =>
    options.UseSqlServer(connectionString));


if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("Connection string is not found or is empty!");
}
else
{
    Console.WriteLine($"Loaded connection string: {connectionString}");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
