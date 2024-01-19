namespace Practica1Nomina.Servicios.Interfaz
{
    public interface IReadJsonFileOptions<T> where T : class
    {
        Task<T> WriteJsonFileOptions(string folder, string filename);
    }
}
