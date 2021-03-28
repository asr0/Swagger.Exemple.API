using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Swagger.Exemple.API.Configurations
{
    public static class ApiProducesAndConsumesConfig
    {
        public static void ApiProducesAndConsumesConfigurations(this MvcOptions options)
        {
            options.ReturnHttpNotAcceptable = true;

            options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
            options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
            options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
            options.Filters.Add(new ProducesAttribute("application/json"));
            options.Filters.Add(new ConsumesAttribute("application/json"));
        }
    }
}
