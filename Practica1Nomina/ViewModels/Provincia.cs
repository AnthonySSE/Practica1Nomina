using Practica1Nomina.DTOs;

namespace Practica1Nomina.ViewModels
{
    public class Provincia:ArchivoJson
    {
        public int province_id { get; set; }
        public string province { get; set; }
        public string codeCountry { get; set; }
    }
}
