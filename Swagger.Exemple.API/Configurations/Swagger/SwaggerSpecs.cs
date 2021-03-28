using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Swagger.Exemple.API.Configurations.Swagger
{
    public static class SwaggerSpecs
    {
        public static string ObterTitulo()
        {
            return "Api de Exemplo do Swagger";
        }

        public static string ObterDescricao(string fileName)
        {
            var descriptionPath = Path.Combine(AppContext.BaseDirectory, $"{fileName}.md");
            var description = File.Exists(descriptionPath) ? File.ReadAllText(descriptionPath) : "Api de Produtos";
            return description;
        }

        internal static OpenApiContact ObterContato()
        {
            return new OpenApiContact()
            {
                Email = "sander@foo.com",
                Name = "Alex Sander",
                Url = new Uri("https://www.google.com.br")
            };
        }
    }

}
