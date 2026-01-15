using AzureApplication.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Controllers register karo (MANDATORY)
builder.Services.AddControllers();

// Swagger (optional but recommended)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infrastructure DI
builder.Services.AddInfrastructure();

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