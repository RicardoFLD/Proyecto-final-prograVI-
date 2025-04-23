using proyecto_final.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final.Models
{ 
[Table("Grados")]
public class Grado
{
    [Key]
    public int IdentificadorGrado { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }

    [Required]
    public string Descripcion { get; set; }
    public virtual ICollection<Carreras> Carreras { get; set; }
}
}