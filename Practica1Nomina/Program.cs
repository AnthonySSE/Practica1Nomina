using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Practica1Nomina;
using Practica1Nomina.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configure Services

var basePath = AppContext.BaseDirectory;
var jsonFolderPath = Path.Combine(basePath, "wwwroot/json/");

try
{
    
    

    var countriesJson = File.ReadAllText(Path.Combine(jsonFolderPath, "countries.json"));
    var provincesJson = File.ReadAllText(Path.Combine(jsonFolderPath, "provinces.json"));
    var municipalitiesJson = File.ReadAllText(Path.Combine(jsonFolderPath, "municipalities.json"));
    var sectorsJson = File.ReadAllText(Path.Combine(jsonFolderPath, "sectors.json"));

    var direccion = new Direccion
    {
        Pais = JsonConvert.DeserializeObject<List<string>>(countriesJson),
        Provincia = JsonConvert.DeserializeObject<List<string>>(provincesJson),
        Municipio = JsonConvert.DeserializeObject<List<string>>(municipalitiesJson),
        Sector = JsonConvert.DeserializeObject<List<string>>(sectorsJson)
    };

    builder.Services.AddSingleton(direccion);
}
catch (Exception)
{

    Console.WriteLine($"Ruta al directorio JSON: {jsonFolderPath}");
    

}


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
