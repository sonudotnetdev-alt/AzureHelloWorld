using AzureApplication.Data;
using AzureApplication.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Controllers register karo (MANDATORY)
builder.Services.AddControllers();

// Swagger (optional but recommended)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Infrastructure DI
//builder.Services.AddInfrastructure();
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 🔥 Controllers map karo (MANDATORY)
app.MapControllers();

app.Run();