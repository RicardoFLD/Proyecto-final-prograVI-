using proyecto_final.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Grado
{
    [Key]
    public int IdGrado { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    public string Descripcion { get; set; }
    public virtual ICollection<Carreras> Carreras { get; set; }
}
