using Microsoft.AspNetCore.Mvc.Rendering;
using Practica1Nomina.Models;
using Practica1Nomina.ViewModels;

namespace Practica1Nomina.Comun.Interfaz
{
    public interface IEmpleadoServices
    {
        Task<IEnumerable<Pais>> ObtenerArchivoDePais();
        Task<IEnumerable<Provincia>> ObtenerArchivoDeProvincia(string codeCountry = "");
        Task<IEnumerable<Municipio>> ObtenerArchivoDeMunicipio();
        Task<IEnumerable<Sector>> ObtenerArchivoDeSector();
        Task<IEnumerable<SelectListItem>> ObtenerListaDePaises(string defaultValue = "");
        Task<IEnumerable<SelectListItem>> ObtenerListaDeProvincias(int defaultValue = 0);
        Task<IEnumerable<SelectListItem>> ObtenerListaDeMunicipios(int defaultValue = 0);
        Task<IEnumerable<SelectListItem>> ObtenerListaDeSectores(int defaultValue = 0);
        Task<IEnumerable<Empleado>> ObtenerEmpleados();
        Task AgregarEmpleado(Empleado empleado);
        Task<Empleado> ObtenerEmpleadosPorId(int id);
        Task ActualizarEmpleado(Empleado empleado);
        Task EliminarEmpleado(int id);
    }
}
