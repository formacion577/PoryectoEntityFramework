using Microsoft.AspNetCore.Mvc;  
using Microsoft.EntityFrameworkCore;
using ProjectoEF.Modelos;
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
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    var DatosTareas=dbContext.Tareas;
    //return Results.Ok(DatosTareas.Include(X=> X.Categoria).Where(x=> x.PrioridadTarea == ProjectoEF.Modelos.Prioridad.Media));
    return Results.Ok(DatosTareas);
});
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaID=Guid.NewGuid();
    tarea.FechaCreacion=DateTime.Now;
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea); Esta es otra forma de hacerlo y esta bien tambien
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});
app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea,[FromRoute] Guid id) =>
{
    var TareaActual= dbContext.Tareas.Find(id);
    if (TareaActual!=null)
    {
        TareaActual.CategoriaId=tarea.CategoriaId;
        TareaActual.Titulo=tarea.Titulo;
        TareaActual.PrioridadTarea=tarea.PrioridadTarea;
        TareaActual.Descripcion=tarea.Descripcion;
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }
    return Results.NotFound();
});

app.Run();  