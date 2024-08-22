using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectoEF.Modelos;

public class Categoria

{
    //Se comentan los atributos por que se realizo en TareasContext con el metodo Fluent API
    //[Key]  
    public Guid CategoriaId {get; set;} // esto es utilizado en las bases de datos relacional para los ID.
    //[Required]   // Con esta propiedad estamos forzando al atributo sea requerida.
    //[MaxLength(150)] // con esta propiedad forzamos a que el atributo no exeda los 150 caracteres.     
    public string Nombre {get; set;}
    public string Descripcion {get;set;} 

    public int Peso {get;set;} 
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;}   
}