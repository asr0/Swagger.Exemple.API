namespace Swagger.Exemple.API.Model
{
    public class Categoria
    {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }

        public Categoria()
        {

        }
        public Categoria(string codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }
    }
}