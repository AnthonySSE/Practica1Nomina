using ProyectoNomina.Servicios.Interfaz;
using System.Text.Json;

namespace ProyectoNomina.Common.Servicios
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
