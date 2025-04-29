using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proyecto_final.Models
{
    [Table("Alumno")]
    public class Alumno
    {
        [Key]
        public int IdentificadorAlumno { get; set; }
        [Required]
        public DateTime Fecha_Ingreso { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required]
        [RegularExpression(@"^[MF]$", ErrorMessage = "Género debe ser 'M' o 'F'")]
        public string Genero { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string PrimerApellido { get; set; }
        [Required]
        public string SegundoApellido { get; set; }
        [Required]
        public string DireccionFisica { get; set; }
        [Required]
        public string TelefonoPrincipal { get; set; }
        [Required]
        public string TelefonoSecundario { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }
        public int IdentificadorProvincia { get; set; }
        [ForeignKey("IdentificadorProvincia")]
        public virtual Provincia Provincia { get; set; }
        public int IdentificadorCanton { get; set; }
        [ForeignKey("IdentificadorCanton")]
        public virtual Canton Canton { get; set; }
        public int IdentificadorDistrito { get; set; }
        [ForeignKey("IdentificadorDistrito")]
        public virtual Distrito Distrito { get; set; }
    }
}