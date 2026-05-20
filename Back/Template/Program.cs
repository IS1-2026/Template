using Application.Interfaces.Cancha;
using Application.Interfaces.Reserva;
using Application.Interfaces.TipoCancha;
using Application.UseCases;
using Infrastructrure.Command;
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

builder.Services.AddSwaggerGen();

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
