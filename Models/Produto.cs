
using System.Text.Json.Serialization;

namespace MenuOn.Models
{
    public class Produto
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string ImagemUrl { get; set; }
        public virtual decimal Preco { get; set; }
        public virtual bool Disponivel { get; set; }
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }

        public Produto() { }

        public Produto(Categoria categoria)
        {
            Categoria = categoria;
        }
    }
}