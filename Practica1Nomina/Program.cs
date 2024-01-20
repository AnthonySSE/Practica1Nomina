using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Practica1Nomina;
using Practica1Nomina.Comun.Interfaz;
using Practica1Nomina.Comun.Servicios;
using Practica1Nomina.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmpleadoServices, EmpleadoServices>();
builder.Services.AddScoped<INominaServices, NominaServices>();
builder.Services.AddScoped(typeof(IReadJsonFileOptions<>), typeof(ReadJsonFileOptions<>));
builder.Services.AddAutoMapper(typeof(Program));

//Configure Services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
