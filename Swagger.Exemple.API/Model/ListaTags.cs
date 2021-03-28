using System.Collections.Generic;

namespace Swagger.Exemple.API.Model
{
    public class ListaTags
    {
        List<Tags> _items;

        public ListaTags()
        {
            _items = new List<Tags>();
        }
        /// <summary>
        /// Lista de tags contidas.
        /// </summary>
        public IReadOnlyList<Tags> Itens => _items;

        /// <summary>
        /// Quantidade de itens.
        /// </summary>
        public int Count => _items.Count;

        public void AdicionarTag(Tags item)
        {
            _items.Add(item);
        }

        public void AdicionarTags(IList<Tags> item)
        {
            _items.AddRange(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(Tags item)
        {
            return _items.Contains(item);
        }

        public IEnumerator<Tags> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public bool Remove(Tags item)
        {
            return _items.Remove(item);
        }       
    }
}
