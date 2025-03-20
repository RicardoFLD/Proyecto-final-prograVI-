using System.ComponentModel.DataAnnotations;

public class Grado
{
    [Key]
    public int IdGrado { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100)]
    public string Nombre { get; set; }

    [StringLength(250)]
    public string Descripcion { get; set; }
}
