using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Service.Validators;
using System.Globalization;
using System.Text.Json.Serialization;

namespace APICadastroUsuario.Configuracoes
{
    public static class FluentValidationConfiguration
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(p => p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
                .AddFluentValidation(p =>
                {
                    p.RegisterValidatorsFromAssemblyContaining<UsuarioValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<NovoUsuarioValidator>();
                    p.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
                    p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
        }
    }
}
