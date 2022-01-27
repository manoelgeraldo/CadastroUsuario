using APICadastroUsuario.Configuracoes;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguracoes();

builder.Services.AddAutoMapperConfiguracoes();

builder.Services.AddDIConfiguracoes();

builder.Services.AddFluentValidationConfiguration();

builder.Services.AddDbContextoConfiguracoes(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguracoes();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
