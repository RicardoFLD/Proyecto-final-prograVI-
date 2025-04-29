using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proyecto_final.Models
{
    [Table("Canton")]
    public class Canton
    {
        [Key]
        public int IdentificadorCanton { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaInsercion { get; set; }
        [Required]
        public DateTime FechaModificacion { get; set; }
        [Required]
        public string usuarioModificacion { get; set; }
        public int IdentificadorProvincia { get; set; }
        [ForeignKey("IdentificadorProvincia")]
        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Distrito> Distritos { get; set; }
        public virtual ICollection<Alumno> Alumno { get; set; }
    }
}