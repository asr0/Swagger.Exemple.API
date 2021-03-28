namespace Swagger.Exemple.API.Model
{
    public class Tags
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public Tags(string nome, string descricao)
        {
            this.Descricao = descricao;
            this.Nome = nome;
        }
    }
}