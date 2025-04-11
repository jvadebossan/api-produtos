
using System.Text.Json.Serialization;

namespace apiProdutos2.Models
{
    public class Categoria
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int OrdemExibicao { get; set; }
        public virtual string ImagemUrl { get; set; }
        public virtual bool Ativo { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
        [JsonIgnore]
        public virtual Menu Menu { get; set; }

        public Categoria() { }

        public Categoria(Menu menu)
        {
            Menu = menu;
        }
    }

}