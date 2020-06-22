using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ucne.Models
{
    public class Empleados
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Código")]
        public int codigo { get; set; }
        [Display(Name = "Cédula")]
        public string cedula { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fechaNacimiento { get; set; }
        [Display(Name = "Fecha de ingreso")]
        public DateTime fechaIngreso { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Display(Name = "Sexo")]
        public char sexo { get; set; }
        [Display(Name = "Estado civil")]
        public string estadoCivil { get; set; }
        [Display(Name = "Ocupación")]
        public string ocupacion { get; set; }
        [Display(Name = "Tipo Sangre")]
        public string tipoSangre { get; set; }
        [Display(Name = "Nacionalidad")]
        public string nacionalidad { get; set; }
        [Display(Name = "Religión")]
        public string religion { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
        [Display(Name = "Salario Mensual")]
        public double salariomensual { get; set; }
        [Display(Name = "Departamento al que pertenece")]
        public string departamento { get; set; }
        [Display(Name = "Contacto de emergencia")]
        public string contactoemergencia { get; set; }
        [Display(Name = "AFP a la que pertenece")]
        public string afp { get; set; }
        [Display(Name = "ARS a la que pertenece")]
        public string ars { get; set; }
        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }
    }
}
