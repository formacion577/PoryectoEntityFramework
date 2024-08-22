using Microsoft.AspNetCore.Mvc;  
using Microsoft.EntityFrameworkCore;  
using proyetoef;  

var builder = WebApplication.CreateBuilder(args);  

// Configura la base de datos SQL Server  
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));  

var app = builder.Build();  

app.MapGet("/", () => "Hello World!");  

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>  
{  
    // Usar migraciones para asegurar que el esquema esté actualizado  
    await dbContext.Database.MigrateAsync();  
    return Results.Ok("Base de datos en SQL Server: " + !dbContext.Database.IsInMemory());  
});
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbconexion) =>
{
    var DatosTareas=dbconexion.Tareas;
    var DatosCategoria=dbconexion.Categorias;
    return Results.Ok(DatosTareas.Include(x=> x.Categoria).Where(x=> x.PrioridadTarea== ProjectoEF.Modelos.Prioridad.Baja));
});

app.Run();  