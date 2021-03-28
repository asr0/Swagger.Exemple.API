using AutoBogus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swagger.Exemple.API.Model;

namespace Swagger.Exemple.API.Endpoints.v1.Controllers
{
    [Route("api/v{version:apiVersion}/categorias")]
    [ApiController]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [ProducesResponseType(400)]
    [ApiVersion("1.0", Deprecated = true)]
    public class CategoriasController : ControllerBase
    {
        /// <summary>
        /// Obter todas as categorias cadastradas da primeira versão
        /// </summary>
        /// <returns>lista de categorias existentes</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Categoria> GetAll()
        {
            var categorias = AutoFaker.Generate<Categoria>(1);
            return Ok(categorias);
        }
    }
}
