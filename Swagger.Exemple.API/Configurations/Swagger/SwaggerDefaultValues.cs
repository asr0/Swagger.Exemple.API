using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Swagger.Exemple.API.Configurations.Swagger
{
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                return;

            var apiDescription = context.ApiDescription;
            operation.Deprecated = apiDescription.IsDeprecated();

            foreach (var parameter in operation.Parameters)
            {
                var description = apiDescription.ParameterDescriptions.FirstOrDefault(p => p.Name == parameter.Name);

                var routeInfo = description.RouteInfo;

                if (string.IsNullOrWhiteSpace(parameter.Description))
                    parameter.Description = description.ModelMetadata?.Description;

                if (routeInfo == null)
                {
                    continue;
                }

                parameter.Required |= description.IsRequired;
            }
        }
    }

}
