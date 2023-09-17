using Microsoft.EntityFrameworkCore;
using Microgame.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//sqlite 
builder.Services.AddDbContext<PlayerContext>(options =>
    options.UseSqlite("Data Source=./microgame.db"));

// builder.Services.AddDbContext<PlayerContext>(opt =>
//     opt.UseInMemoryDatabase("Microgame"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
