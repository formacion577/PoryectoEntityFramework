using Microsoft.EntityFrameworkCore;
using ProjectoEF.Modelos;

/*n resumen, TareasContext es un contexto de 
base de datos en EF Core que se utiliza para acceder y 
manipular dos conjuntos de entidades: Categoria y Tarea. 
Facilita operaciones como agregar, eliminar, actualizar y consultar 
estas entidades en la base de datos que está configurada a través 
de los DbContextOptions*/

namespace proyetoef;
public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}
    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}
}