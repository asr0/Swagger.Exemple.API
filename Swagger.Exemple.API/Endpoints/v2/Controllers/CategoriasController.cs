using AutoBogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swagger.Exemple.API.Model;

namespace Swagger.Exemple.API.Endpoints.v2.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/categorias")]
    public class CategoriasController : ControllerBase
    {
        /// <summary>
        /// Obter todas as categorias cadastradas da segunda versão
        /// </summary>
        /// <returns>lista de categorias existentes</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Categoria> GetAll()
        {
            var categorias = AutoFaker.Generate<Categoria>(50);
            return Ok(categorias);
        }
    }
}
