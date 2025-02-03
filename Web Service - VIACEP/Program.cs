using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configurar o servi�o HTTP para a API ViaCEP com URL base
builder.Services.AddHttpClient<ViaCepService>(client =>
{
    client.BaseAddress = new Uri("https://viacep.com.br/ws/");
});

// Adicionar servi�os do controlador
builder.Services.AddControllers();

// Configurar o Swagger (documenta��o da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar roteamento e controle de requisi��es
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Iniciar a aplica��o
app.Run();
