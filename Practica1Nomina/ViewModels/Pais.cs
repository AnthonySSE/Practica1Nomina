using Practica1Nomina.DTOs;

namespace Practica1Nomina.ViewModels
{
    public class Pais:ArchivoJson
    {
        public string name { get; set; }
        public string code { get; set; }
        public virtual ICollection<Provincia> Provincias { get; set; }
    }
}
