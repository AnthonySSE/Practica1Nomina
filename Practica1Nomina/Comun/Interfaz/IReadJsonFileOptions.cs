namespace Practica1Nomina.Comun.Interfaz
{
    public interface IReadJsonFileOptions<T> where T : class
    {
        Task<T> WriteJsonFileOptions(string folder, string filename);
    }
}
