using Microsoft.AspNetCore.Mvc;  
using Microsoft.EntityFrameworkCore;  
using proyetoef;  

var builder = WebApplication.CreateBuilder(args);  

// Configura la base de datos SQL Server  
builder.Services.AddSqlServer<TareasContext>("Server=DESKTOP-CB6U2F4\\MSSQLSERVER2;Database=TareasDb;User Id=sa;Password=123;Encrypt=false;");  

var app = builder.Build();  

app.MapGet("/", () => "Hello World!");  

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>  
{  
    dbContext.Database.EnsureCreated();  
    return Results.Ok("Base de datos en SQL Server: " + !dbContext.Database.IsInMemory());  
});  
app.Run();  