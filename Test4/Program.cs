using Microsoft.EntityFrameworkCore;
using Test4.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var ConnectString = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<CFContext>(tvcOptions => tvcOptions.UseSqlServer(ConnectString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
