using AutoBogus;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swagger.Exemple.API.Model;

namespace Swagger.Exemple.API.Endpoints.v1.Controllers
{
    [Route("api/v{version:apiVersion}/produtos")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProdutosController : ControllerBase
    {
        /// <summary>
        /// Obter todos os produtos da loja
        /// </summary>
        /// <returns>lista de produtos existentes</returns>
        [HttpGet]
        public ActionResult<Produto> GetAll()
        {
            var produtos = AutoFaker.Generate<Produto>(50);
            return Ok(produtos);
        }

        /// <summary>
        /// Obtem um produto
        /// </summary>
        /// <param name="id">Identificador Único do Produto</param>
        /// <returns>Retorno um produto baseado em seu Id</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            Produto produto = new Faker<Produto>("pt_BR")
                .CustomInstantiator(f => new Produto(f.Commerce.ProductName(), f.Random.Decimal(), f.Date.SoonOffset(), f.Random.Bool()))
                .RuleFor(f=> f.Id, f=> id)
                .Generate();

            return Ok(produto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public IActionResult Post(Produto produto)
        {

            return Created("http://google.com.br",produto);
        }
    }
}
