using Microsoft.EntityFrameworkCore;
using TiendaMascotas_API.Models;
using TiendaMascotas_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(options => options.AddPolicy("Policy",
                                builder => builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod()));

//Context
builder.Services.AddDbContext<PeluditosDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));

});

//Inyección de dependencias
builder.Services.AddScoped<CategoriaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
