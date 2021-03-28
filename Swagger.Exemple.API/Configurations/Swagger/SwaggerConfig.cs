using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swagger.Exemple.API.Configurations.Swagger
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfigurations(this IServiceCollection services)
        {
            services.AddSwaggerOptionsDependencyInjection();

            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();

                options.AddSecuritySchemas();

                options.IncludeXmlCommentsIfExists();
            });

            return services;
        }
   
        public static IApplicationBuilder UseSwaggerConfigurations(this IApplicationBuilder app, IApiVersionDescriptionProvider provider, IWebHostEnvironment env)
        {
            if (env.IsProduction())
            {
                app.UseMiddleware<SwaggerAuthorizedMiddleware>();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.InjectStylesheet("/Assets/swagger-ui/custom.css");
                options.InjectJavascript("/Assets/swagger-ui/custom.js");
                AddSwaggerJsonEndpoint(provider, options);

                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                options.DefaultModelExpandDepth(2);
                options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                options.EnableDeepLinking();
                options.DisplayOperationId();
            });         

            return app;
        }

        private static void AddSwaggerJsonEndpoint(IApiVersionDescriptionProvider provider, Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        }

        public static IServiceCollection AddSwaggerOptionsDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            return services;
        }
    }

}
