using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectoEF.Modelos;
public class Tarea
{
   //[Key]
    public Guid TareaID {get;set;}
    //[ForeignKey("CategoriaId")] // Esto es Importante para las llaves foraneas en base de datos.
    public Guid CategoriaId {get;set;}
   // [Required]
   // [MaxLength(200)]
    public string Titulo {get;set;}
    public string Descripcion {get;set;}
    public Prioridad PrioridadTarea {get;set;}
    public DateTime FechaCreacion {get;set;}
    public virtual Categoria Categoria {get;set;}
    //[NotMapped]  // este atributo es importante para que no sea en cuenta en la base de dato 
    public string Resumen {get;set;}
 }

 public enum Prioridad
 {
    Baja,
    Media,
    Alta,
 }
