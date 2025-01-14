using DigitalCursos.Api.Context;
using DigitalCursos.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Sqlite");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connectionString));
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
