using System;
using System.ComponentModel.DataAnnotations;

namespace Swagger.Exemple.API.Model
{
    /// <summary>
    /// Entidade que representa um produto
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Identificador único do produto
        /// </summary>
        public int Id { get;  set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        [Required]
        public string Nome { get;  set; }

        /// <summary>
        /// Preço do produto (decimal)
        /// </summary>
        [Required]
        public decimal Preco { get;  set; }
        /// <summary>
        /// Data em que o produto foi lançado
        /// </summary>
        public DateTimeOffset? DataLancamento { get;  set; }
        /// <summary>
        /// Disponibilidade do produto
        /// </summary>
        public bool Disponivel { get;  set; }
        /// <summary>
        /// Categoria do produto
        /// </summary>
        public Categoria Categoria { get;  set; }
        /// <summary>
        /// Lista de tags que o produto pertence
        /// </summary>
        public ListaTags ListaTags { get;  set; }


        public Produto()
        {

        }
        public Produto(string nome, decimal preco, DateTimeOffset dataLancamento, bool disponivel = true)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.DataLancamento = dataLancamento;
            this.Disponivel = disponivel;
            this.ListaTags = new ListaTags();
            this.Categoria = new Categoria();
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            this.Categoria = categoria;
        }

        public void AdicionarTag(string nome, string descricao)
        {

            if (this.ListaTags == null)
            {
                this.ListaTags = new ListaTags();
            }
            this.ListaTags.AdicionarTag(new Tags(nome, descricao));
        }
    }
}
