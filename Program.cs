using Entity_Framework_Platzi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;user Id=turko;password=superman17;
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("SqlServerConectTareas"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Conexión exitosa: " + dbContext.Database.CanConnect());
});

app.Run();
