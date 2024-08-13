using System.ComponentModel.DataAnnotations;

namespace ProjectoEF.Modelos;

public class Categoria
{
    [Key]
    public Guid CategoriaID {get; set;} // esto es utilizado en las bases de datos relacional para los ID.
    [Required]   // Con esta propiedad estamos forzando al atributo sea requerida.
    [MaxLength(150)] // con esta propiedad forzamos a que el atributo no exeda los 150 caracteres.     
    public string Nombre {get; set;}
    public string Descripcion {get;set;}  
    public virtual ICollection<Tarea> Tareas {get;set;}   
}