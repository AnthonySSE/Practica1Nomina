using Practica1Nomina.DTOs;

namespace Practica1Nomina.ViewModels
{
    public class Sector:ArchivoJson
    {
        public int municipio_id { get; set; }
        public long sector_id { get; set; }
        public string sector { get; set; }
    }
}
