using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proyecto_final.Models
{
    [Table("Provincia")]
    public class Provincia
    {
        [Key]
        public int IdentificadorProvincia { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaInsercion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        [Required]
        public string usuarioModificacion { get; set; }

        public virtual ICollection<Canton> Cantones { get; set; }
        public virtual ICollection<Alumno> Alumno { get; set; }
    }
}