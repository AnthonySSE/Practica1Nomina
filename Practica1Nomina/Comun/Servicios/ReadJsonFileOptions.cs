using Practica1Nomina.Comun.Interfaz;
using System.Text.Json;

namespace Practica1Nomina.Comun.Servicios
{
    public class ReadJsonFileOptions<T> : IReadJsonFileOptions<T> where T : class
    {
        public async Task<T> WriteJsonFileOptions(string folder, string filename)
        {
            string filePath = Path.Combine(folder, filename);
            string jsonString = File.ReadAllText(filePath);
            return await Task.FromResult(JsonSerializer.Deserialize<T>(jsonString)!);
        }
    }
}
