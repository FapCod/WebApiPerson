using Microsoft.EntityFrameworkCore;
using WebApiPerson.Context;

var builder = WebApplication.CreateBuilder(args);
//crear variable para cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//agregar cadena de conexion a la base de datos
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
