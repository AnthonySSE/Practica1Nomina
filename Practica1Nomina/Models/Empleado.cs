using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica1Nomina.Models
{
    public class Empleado
    {
        /*3.	Para el caso del Empleado deberá crear una clase que contenga las siguientes propiedades:
a.	Id
b.	Nombre
c.	Apellidos
d.	Edad
e.	Fecha Nacimiento
f.	Sexo
g.	Salario
h.	País, Provincia, Municipio y Barrios
i.	 (Deberá ser in IColletion que se llenará de un Json el mismo que está en el virtual).
j.	Si posee licencia
*/
        public enum Genero
        {
            Masculino,
            Femenino
        }
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Edad { get; set; }
        [Display(Name="Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public Genero Sexo { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Salario { get; set; }
        public string? Pais { get; set; }
        public int? Provincia { get; set; }
        public int? Municipio { get; set; }
        public long? Sector { get; set; }
        public bool Licencia { get; set; }
    }
}
