using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swagger.Exemple.API.Configurations.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CriarInformacoesParaApiVersion(description));
            }
        }

        private OpenApiInfo CriarInformacoesParaApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = SwaggerSpecs.ObterTitulo(),
                Description = SwaggerSpecs.ObterDescricao("swagger-api-description"),
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
            {
                info.Description += " Esta Api está obsoleta!";
            }

            return info;
        }
    }

}
