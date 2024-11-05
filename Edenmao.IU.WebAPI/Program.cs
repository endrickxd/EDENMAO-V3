using Microsoft.EntityFrameworkCore;
using Edenmao.Infrastructure.Data;
using Edenmao.Infrastructure.FileLogger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Edenmao.Infrastructure.Mappings;
using Edenmao.Core.Interfaces;
using Edenmao.Domain.Entities;
using Edenmao.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddProvider(new FileLoggerProvider("logs.txt"));
});

builder.Services.AddScoped<IRepository<Articulo>, ArticuloRepository>();
builder.Services.AddScoped<IRepository<Categoria>, CategoriaRepository>();
builder.Services.AddScoped<IRepository<Cliente>, ClienteRepository>();
builder.Services.AddScoped<IRepository<Personificacion>, PersonificacionRepository>();
builder.Services.AddScoped<IRepository<Rol>, RolRepository>();


builder.Services.AddAutoMapper(typeof(MappingProfile));

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
