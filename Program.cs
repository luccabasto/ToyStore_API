using ToyStore_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Servi�os
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("ToyStoreConnection")));

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles(); // permite carregar arquivos como CSS futuramente

// Rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToysView}/{action=Index}/{id?}");

app.MapControllers();

// Swagger acess�vel somente via /swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToyStore API v1");
    c.RoutePrefix = "swagger"; // evita abrir na home
});

app.Run();
