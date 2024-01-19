using Practica1Nomina.Models;

namespace Practica1Nomina.Comun.Interfaz
{
    public interface INominaServices
    {
        Task<IEnumerable<Nomina>> ObtenerNominas();
        Task AgregarNomina (Nomina nomina);
        Task<Nomina> ObtenerNominaPorId(int id);
        Task ActualizarNomina(Nomina nomina);
        Task EliminarNomina(int id);
    }
}
