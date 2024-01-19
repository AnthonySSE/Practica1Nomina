using Practica1Nomina.Comun.Interfaz;
using Practica1Nomina.Models;

namespace Practica1Nomina.Comun.Servicios
{
    public class NominaServices : INominaServices
    {
        private readonly List<Nomina> _listNominas = new List<Nomina>();

        public NominaServices()
        {
            _listNominas = new List<Nomina>();
        }
        public async Task AgregarNomina(Nomina nomina)
        {
            nomina.Id = _listNominas.Count + 1;
            _listNominas.Add(nomina);
        }

        public async Task EliminarNomina(int id)
        {
            var nominaExistente = _listNominas.FirstOrDefault(x => x.Id == id);
            if(nominaExistente !=null)
            {
                _listNominas.Remove(nominaExistente);
            }
        }

        public async Task<Nomina> ObtenerNominaPorId(int id)
        {
            return _listNominas.FirstOrDefault(x=>x.Id == id);

        }

        public async Task<IEnumerable<Nomina>> ObtenerNominas()
        {
            return _listNominas;
        }

        public async Task ActualizarNomina(Nomina nomina)
        {
           var nominaActualizada = _listNominas.FirstOrDefault(x=>x.Id==nomina.Id);
            if(nominaActualizada != null)
            {
                nominaActualizada.ISR = nomina.ISR;
                nominaActualizada.SueldoNeto = nomina.SueldoNeto;
                nominaActualizada.SueldoBruto = nomina.SueldoBruto;
                nominaActualizada.TSS = nomina.TSS;
                nominaActualizada.FechaCreacion = nomina.FechaCreacion;
                nominaActualizada.FechaNomina = nomina.FechaNomina;

                _listNominas.Add(nominaActualizada);
            }
        }
    }
}
