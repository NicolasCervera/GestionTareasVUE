using back_gestion_tareas.Context;
using backend_gestion_tareas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(
    options=> options.UseMySql(builder.Configuration.GetConnectionString("MySQLConnection"), serverVersion));

var app = builder.Build();
startup.Configure(app, app.Lifetime);



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

