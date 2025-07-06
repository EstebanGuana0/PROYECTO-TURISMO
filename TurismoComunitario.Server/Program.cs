using Microsoft.EntityFrameworkCore;
using TurismoComunitario.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar DbContext con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar CORS para permitir solicitudes desde una app React
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .WithOrigins("https://localhost:64076")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Habilitar CORS
app.UseCors("AllowReactApp");

app.UseDefaultFiles();
app.UseStaticFiles();

// Habilitar Swagger solo en desarrollo


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
