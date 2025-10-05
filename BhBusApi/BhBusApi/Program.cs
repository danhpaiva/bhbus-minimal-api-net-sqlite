using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BhBusApi.Data;
using BhBusApi.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BhBusApiContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BhBusApiContext") ?? throw new InvalidOperationException("Connection string 'BhBusApiContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapOnibusEndpoints();

app.Run();