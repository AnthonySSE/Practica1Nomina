using Microsoft.AspNetCore.Mvc.Rendering;
using Practica1Nomina.Comun.Interfaz;
using Practica1Nomina.Models;
using Practica1Nomina.Comun.Servicios;
using Practica1Nomina.ViewModels;

namespace Practica1Nomina.Comun.Servicios
{
    public class EmpleadoServices : IEmpleadoServices
    {
        private readonly List<Empleado> _empleadoList = new List<Empleado>();
        private readonly IHostEnvironment hostEnvironment;
        private readonly IReadJsonFileOptions<IEnumerable<Pais>> readJsonFileOptionsPais;
        private readonly IReadJsonFileOptions<IEnumerable<Provincia>> readJsonFileOptionsProvincia;
        private readonly IReadJsonFileOptions<IEnumerable<Municipio>> readJsonFileOptionsMunicipio;
        private readonly IReadJsonFileOptions<IEnumerable<Sector>> readJsonFileOptionsSector;


        public EmpleadoServices(IHostEnvironment hostEnvironment,
            IReadJsonFileOptions<IEnumerable<Pais>> readJsonFileOptionsPais,
            IReadJsonFileOptions<IEnumerable<Provincia>> readJsonFileOptionsProvincia,
            IReadJsonFileOptions<IEnumerable<Municipio>> readJsonFileOptionsMunicipio,
            IReadJsonFileOptions<IEnumerable<Sector>> readJsonFileOptionsSector)
        {
            this.hostEnvironment = hostEnvironment;
            this.readJsonFileOptionsPais = readJsonFileOptionsPais;
            this.readJsonFileOptionsProvincia = readJsonFileOptionsProvincia;
            this.readJsonFileOptionsMunicipio = readJsonFileOptionsMunicipio;
            this.readJsonFileOptionsSector = readJsonFileOptionsSector;
            _empleadoList = new List<Empleado>();
        }



        /*JSON*/
        public async Task<IEnumerable<Municipio>> ObtenerArchivoDeMunicipio()
        {
            try
            {
                string folder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/json/");
                string fileName = "municipalities.json";
                return await readJsonFileOptionsMunicipio.WriteJsonFileOptions(folder, fileName);
            }
            catch (Exception ex)
            {
                // Manejar la excepción (puedes imprimir el mensaje en la consola o el registro)
                Console.WriteLine($"Error al obtener el archivo de municipios: {ex.Message}");
                throw;
            }
        }


        public async Task<IEnumerable<SelectListItem>> ObtenerListaDeMunicipios(int defaultValue = 0)
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            foreach(var item in await ObtenerArchivoDeMunicipio())
            {
                listItem.Add(new SelectListItem 
                { 
                    Value = item.municipality_id.ToString() , 
                    Text=item.municipality, 
                    Selected=defaultValue == item.municipality_id
                });
            }
            return listItem;
        }

        public async Task<IEnumerable<Pais>> ObtenerArchivoDePais()
        {
            string folder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/json/");
            string fileName = "countries.json";
            return await readJsonFileOptionsPais.WriteJsonFileOptions(folder, fileName);
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerListaDePaises(string defaultValue = "")
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in await ObtenerArchivoDePais())
            {
                listItems.Add(new SelectListItem 
                {
                    Value = item.code.ToString(), 
                    Text=item.name, 
                    Selected=defaultValue == item.code
                });
            }
            return listItems;
        }

        public async Task<IEnumerable<Provincia>> ObtenerArchivoDeProvincia(string codeCountry = "")
        {
            string folder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/json/");
            string fileName = "provinces.json";
            var result = await readJsonFileOptionsProvincia.WriteJsonFileOptions(folder, fileName);
            if (!string.IsNullOrEmpty(codeCountry))
                result.Where(x => x.codeCountry == codeCountry);
            return result; 
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerListaDeProvincias(int defaultValue = 0)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in await ObtenerArchivoDeProvincia())
            {
                listItems.Add(new SelectListItem { 
                    Value = item.province_id.ToString(), 
                    Text = item.province, 
                    Selected = defaultValue == item.province_id 
                });
            }
            return listItems;
        }

        public async Task<IEnumerable<Sector>> ObtenerArchivoDeSector()
        {
            string folder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/json/");
            string fileName = "sectors.json";
            return await readJsonFileOptionsSector.WriteJsonFileOptions(folder, fileName);
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerListaDeSectores(int defaultValue = 0)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in await ObtenerArchivoDeSector())
            {
                listItems.Add(new SelectListItem { 
                    Value = item.sector_id.ToString(), 
                    Text = item.sector, 
                    Selected = defaultValue == item.municipio_id 
                });
            }
            return listItems;
        }
        

        /*CRUD*/

        private int ObtenerIdEmpleado()
        {
            if(_empleadoList.Count == 0)
            {
                return 1;
            }
            else
            {
                int idMax = _empleadoList.Max(x => x.Id);
                return idMax + 1;
            }
        }

        public async Task<IEnumerable<Empleado>> ObtenerEmpleados()
        {
            return _empleadoList;
        }
        public async Task AgregarEmpleado(Empleado empleado)
        {
            if(empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado));  
            }
            empleado.Id = ObtenerIdEmpleado();
            
             _empleadoList.Add(empleado);
        }

        public async Task<Empleado> ObtenerEmpleadosPorId(int id)
        {
            return _empleadoList.FirstOrDefault(x=>x.Id == id);
        }

        public async Task ActualizarEmpleado(Empleado empleado)
        {
            var empleadoActualizado = _empleadoList.FirstOrDefault(x=>x.Id ==empleado.Id);
            if(empleadoActualizado != null)
            {
                empleadoActualizado.Nombre = empleado.Nombre; 
                empleadoActualizado.Apellido = empleado.Apellido;
                empleadoActualizado.Edad = empleado.Edad;
                empleadoActualizado.FechaNacimiento = empleado.FechaNacimiento;
                empleadoActualizado.Sexo = empleado.Sexo;
                empleadoActualizado.Salario = empleado.Salario;
                empleadoActualizado.Pais = empleado.Pais;
                empleadoActualizado.Provincia = empleado.Provincia;
                empleadoActualizado.Municipio = empleado.Municipio;
                empleadoActualizado.Sector = empleado.Sector;

                _empleadoList.Add(empleadoActualizado);
            }
        }

        public async Task EliminarEmpleado(int id)
        {
            var empleadoExistente = _empleadoList.FirstOrDefault(x=>x.Id == id);
            if(empleadoExistente != null)
            {
                _empleadoList.Remove(empleadoExistente);
            }
        }
        
    }
}
