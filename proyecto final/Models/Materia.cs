using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_final.Models
{
    public class Materia
    {
        [Key]
        public int IdentificadorMateria { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre único de materia.")]
        [Remote("ValidarNombre", "Materias", ErrorMessage = "El nombre de materia ya existe.")]
        public string Nombre { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public int NumeroCreditos { get; set; }
        [Required]
        public int NumeroHoras { get; set; }

        /**public virtual ICollection<MateriasCarrera> MateriasCarreras { get; set; }*/
    }
}
