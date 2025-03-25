using ToyStore_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configuraçao do Banco de Dados Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("ToyStoreConnection")));

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ToyStore API",
        Version = "v1",
        Description = "Este sistema realiza cadastro de Brinquedos para a empresa, permitindo a gestão de informações como nome, tipo, classificação, tamanho e preço dos brinquedos.",
        Contact = new OpenApiContact
        {
            Name = "ToyStore API",
            Url = new Uri("https://github.com/luccabasto/ToyStore_API")
        }
    });

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
