using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Odontoprev.Data;
using Odontoprev.Repositories;
using Odontoprev.Repositories.Interfaces;
using Odontoprev.Services;
using Odontoprev.Services.Interfaces;
using Odontoprev.Singleton;

var builder = WebApplication.CreateBuilder(args);

// Registro do gerenciador de configurações (Singleton)
builder.Services.AddSingleton<ConfigManager>(ConfigManager.Instance);

// Configuração da conexão com o Oracle via Options Pattern
builder.Services.Configure<OracleSettings>(builder.Configuration.GetSection("OracleSettings"));

// Registro dos repositórios
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddScoped<IFaturamentoRepository, FaturamentoRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IProcedimentoRepository, ProcedimentoRepository>();
builder.Services.AddScoped<IProfissionalRepository, ProfissionalRepository>();

// Registro dos services
builder.Services.AddScoped<IConsultaService, ConsultaService>();
builder.Services.AddScoped<IFaturamentoService, FaturamentoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IProcedimentoService, ProcedimentoService>();
builder.Services.AddScoped<IProfissionalService, ProfissionalService>();

// Adiciona os controllers
builder.Services.AddControllers();

// Configuração do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Inclusão dos comentários XML para enriquecer a documentação
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();