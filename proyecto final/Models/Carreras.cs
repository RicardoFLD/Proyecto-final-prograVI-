using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace proyecto_final.Models
{
    public class Carreras
    {
        [Key]
        public int IdentificadorCarrera { get; set; }
        /*[Required(ErrorMessage = "Debe ingresar un nombre único de carrera.")]
        [Remote("ValidarNombre", "Carreras", ErrorMessage = "El nombre de la carrera ya existe.")]*/
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public int Id_Grado { get; set; }
        [ForeignKey("Id_Grado")]
        public virtual Grado Grado { get; set; }
    }
}