using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ucne.Models
{
    public class Estudiantes
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Matrícula")]
        public int matricula { get; set; }
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
        [Display(Name = "Nombre del padre")]
        public string nombrePadre { get; set; }
        [Display(Name = "Nombre de la madre")]
        public string nombreMadre { get; set; }
        [Display(Name = "Direccion")]
        public string direccion { get; set; }
        [Display(Name = "Tipo de colegio")]
        public string tipoColegio { get; set; }
        [Display(Name = "Carrera")]
        public string carrera { get; set; }
        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }
    }
}
