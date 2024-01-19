using ProyectoNomina.Common.Interfaz;
using ProyectoNomina.Models;

namespace ProyectoNomina.Common.Servicios
{
    public class NominaServices : INominaServices
    {
        private readonly List<Nomina> _listNominas = new List<Nomina>();

        public NominaServices()
        {
            _listNominas = new List<Nomina>();
        }
        public async Task AddNomina(Nomina nomina)
        {
            nomina.Id = _listNominas.Count + 1;
            _listNominas.Add(nomina);
        }

        public async Task DeleteNominaById(int id)
        {
            var nominaExistente = _listNominas.FirstOrDefault(x => x.Id == id);
            if(nominaExistente !=null)
            {
                _listNominas.Remove(nominaExistente);
            }
        }

        public async Task<Nomina> GetNominaById(int id)
        {
            return _listNominas.FirstOrDefault(x=>x.Id == id);

        }

        public async Task<IEnumerable<Nomina>> GetNominas()
        {
            return _listNominas;
        }

        public async Task UpdateNomina(Nomina nomina)
        {
           var nominaActualizada = _listNominas.FirstOrDefault(x=>x.Id==nomina.Id);
            if(nominaActualizada != null)
            {
                nominaActualizada.ISR = nomina.ISR;
                nominaActualizada.SueldoNeto = nomina.SueldoNeto;
                nominaActualizada.SueldoBruto = nomina.SueldoBruto;
                nominaActualizada.Tss = nomina.Tss;
                nominaActualizada.FechaCreacion = nomina.FechaCreacion;
                nominaActualizada.FechaNomina = nomina.FechaNomina;

                _listNominas.Add(nominaActualizada);
            }
        }
    }
}
