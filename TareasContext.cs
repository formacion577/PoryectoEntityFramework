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
    protected override void OnModelCreating(ModelBuilder modelBuilder) // esto se hace para hacer las restricciones de la clase categoria
    {
        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria"); // Con esto se crea la clase categoria en una tabla 
            categoria.HasKey(x=> x.CategoriaId);
            categoria.Property(x=> x.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(x=> x.Descripcion);
        });

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(x=> x.TareaID);
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);
            tarea.Property(x=> x.Titulo).IsRequired().HasMaxLength(250);
            tarea.Property(x=> x.Descripcion);
            tarea.Property(x=> x.PrioridadTarea);
            tarea.Property(x=> x.Categoria);
        });

    }    
}