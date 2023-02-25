using Entity_Framework_Platzi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;user Id=turko;password=superman17;
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

builder.Services.AddSqlServer<TareasContext>("Data Source=E000158\\SQLEXPRESS;Database=master;Initial Catalog=TareasDb;Trust Server Certificate=true;Trusted_Connection=Yes");


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.CanConnect());
});

app.Run();
