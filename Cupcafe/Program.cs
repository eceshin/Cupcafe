using Cupcafe.Service.Data;
using CupCafe.Service.Core;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // Session desteðini ekleyin

builder.Services.AddScoped<UrunService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<AnaSayfaService>();

builder.Services.AddScoped<KullaniciUrunService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}



app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession(); // Session ara yazýlýmýný ekleyin

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
