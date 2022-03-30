using EX04_API.Datas;
using EX04_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var dbLocation = Path.Combine(Environment.CurrentDirectory, "SQLite", "ASTON_TDD_EXO04.db");

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options
    => options.UseSqlite($"Data Source = {dbLocation}")
    .LogTo(Console.WriteLine, LogLevel.Information));
builder.Services.AddScoped<IRepository<Address>, AddressesRepository>();
builder.Services.AddScoped<IRepository<Master>, MastersRepository>();
builder.Services.AddScoped<IRepository<Dog>, DogsRepository>();

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
