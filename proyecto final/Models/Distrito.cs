using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto_final.Models
{
    [Table("Distrito")]
    public class Distrito
    {
   
        [Key]
        public int IdentificadorDistrito { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaInsercion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        [Required]
        public string usuarioModificacion { get; set; }
        public int IdentificadorCanton { get; set; }
        [ForeignKey("IdentificadorCanton")]
        public virtual Canton Canton{ get; set; }
        public virtual ICollection<Alumno> Alumno { get; set; }
    }
}