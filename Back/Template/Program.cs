using Application.Interfaces;
using Application.Interfaces.Asistencia;
using Application.Interfaces.Cancha;
using Application.Interfaces.Clase;
using Application.Interfaces.Cliente;
using Application.Interfaces.Entrenamiento;
using Application.Interfaces.HorarioCancha;
using Application.Interfaces.Incripcion;
using Application.Interfaces.Reserva;
using Application.Interfaces.TipoCancha;
using Application.UseCases;
using Infrastructrure.Command;
using Infrastructrure.Query;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.MapType<TimeSpan>(() => new Microsoft.OpenApi.Models.OpenApiSchema
    {
        Type = "string",
        Example = new Microsoft.OpenApi.Any.OpenApiString("10:00:00")
    });

    c.MapType<DayOfWeek>(() => new Microsoft.OpenApi.Models.OpenApiSchema
    {
        Type = "string",
        Example = new Microsoft.OpenApi.Any.OpenApiString("Monday")
    });
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));




//Inyecciones de dependencia

//Cancha
builder.Services.AddScoped<ICanchaCommand, CanchaCommand>();
builder.Services.AddScoped<ICanchaQuery, CanchaQuery>();
builder.Services.AddScoped<ICanchaService, CanchaService>();


//TipoCancha
builder.Services.AddScoped<ITipoCanchaService, TipoCanchaService>();
builder.Services.AddScoped<ITipoCanchaCommand, TipoCanchaCommand>();
builder.Services.AddScoped<ITipoCanchaQuery, TipoCanchaQuery>();


//Reservas
builder.Services.AddScoped<IReservaServices, ReservaService>();
builder.Services.AddScoped<IReservaCommand, ReservaCommand>();
builder.Services.AddScoped<IReservaQuery, ReservaQuery>();

//Reporte
builder.Services.AddScoped<IReporteService, ReporteService>();
builder.Services.AddScoped<IReporteCommand, ReporteCommand>();
builder.Services.AddScoped<IReporteQuery, ReporteQuery>();

//Clientes
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteCommand, ClienteCommand>();
builder.Services.AddScoped<IClienteQuery, ClienteQuery>();


//Horario Cancha
builder.Services.AddScoped<IHorarioCanchaService, HorarioCanchaService>();
builder.Services.AddScoped<IHorarioCanchaQuery, HorarioCanchaQuery>();
builder.Services.AddScoped<IHorarioCanchaCommand, HorarioCanchaCommand>();
//Asistencia
builder.Services.AddScoped<IAsistenciaService, AsistenciaService>();
builder.Services.AddScoped<IAsistenciaQuery, AsistenciaQuery>();
builder.Services.AddScoped<IAsistenciaCommand, AsistenciaCommand>();
//Entrenamiento
builder.Services.AddScoped<IEntrenamientoService, EntrenamientoService>();
builder.Services.AddScoped<IEntrenamientoQuery, EntrenamientoQuery>();
builder.Services.AddScoped<IEntrenamientoCommand, EntrenamientoCommand>();
//Clase
builder.Services.AddScoped<IClaseService, ClaseService>();
builder.Services.AddScoped<IClaseQuery, ClaseQuery>();
builder.Services.AddScoped<IClaseCommand, ClaseCommand>();
//Inscripción
builder.Services.AddScoped<IInscripcionService, InscripcionService>();
builder.Services.AddScoped<IInscripcionQuery, InscripcionQuery>();
builder.Services.AddScoped<IInscripcionCommand, InscripcionCommand>();

//CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowFront", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowFront");


app.UseAuthorization();

app.MapControllers();

app.Run();
