using Practica1Nomina.DTOs;

namespace Practica1Nomina.ViewModels
{
    public class Municipio:ArchivoJson
    {
        public int province_id { get; set; }
        public int municipality_id { get; set; }
        public string municipality { get; set; }
    }
}
