using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using PMS.API.Data;
using PMS.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PMSDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("PMSDbConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(policy=>policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
