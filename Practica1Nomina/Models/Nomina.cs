using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica1Nomina.Models
{
    public class Nomina
    {
        /*
         * 4.	Para el caso de la nómina la clase tendrá las siguientes propiedades:
a.	Sueldo Bruto
b.	Sueldo Neto
c.	TSS
d.	ISR
e.	Fecha Creación
f.	Fecha Nomina
         */
        public int Id { get; set; }
        [Display(Name = "Sueldo Bruto")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SueldoBruto { get; set; }
        [Display(Name = "Sueldo Neto")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SueldoNeto { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TSS { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal ISR { get; set; }
        [Display(Name = "Fecha de Creación")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNomina { get; set; }
    }
}
