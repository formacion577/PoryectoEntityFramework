using Microsoft.EntityFrameworkCore;  
using ProjectoEF.Modelos;  

namespace proyetoef  
{  
    /* Resumen: TareasContext es un contexto de base de datos en EF Core   
       que se utiliza para acceder y manipular dos conjuntos de entidades:   
       Categoria y Tarea. Facilita operaciones como agregar, eliminar,   
       actualizar y consultar estas entidades en la base de datos que está   
       configurada a través de los DbContextOptions */  
           
    public class TareasContext : DbContext  
    {  
        public DbSet<Categoria> Categorias { get; set; }  
        public DbSet<Tarea> Tareas { get; set; }  

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) {}  

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            modelBuilder.Entity<Categoria>(categoria =>  
            {  
                categoria.ToTable("Categoria"); // Nombre de la tabla  
                categoria.HasKey(x => x.CategoriaId); // Clave primaria  
                categoria.Property(x => x.Nombre).IsRequired().HasMaxLength(150);  
                categoria.Property(x => x.Descripcion);  
            });  

            modelBuilder.Entity<Tarea>(tarea =>  
            {  
                tarea.ToTable("Tarea"); // Nombre de la tabla  
                tarea.HasKey(x => x.TareaID); // Clave primaria  
                tarea.HasOne(p => p.Categoria) // Relación uno a muchos  
                     .WithMany(p => p.Tareas)  
                     .HasForeignKey(p => p.CategoriaId)  
                     .OnDelete(DeleteBehavior.Cascade); // Eliminación en cascada  

                tarea.Property(x => x.Titulo).IsRequired().HasMaxLength(250);  
                tarea.Property(x => x.Descripcion);  
                tarea.Property(x => x.PrioridadTarea);
                tarea.Ignore(x=> x.Resumen); 
                
            });  
        }  
    }  
}  