
using System.Text.Json.Serialization;

namespace MenuOn.Models
{
    public class Menu
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool Ativo { get; set; }
        [JsonIgnore]
        public virtual Loja Loja { get; set; }
        public virtual IList<Categoria> Categorias { get; set; }

        public Menu() { }

        public Menu(Loja loja)
        {
            Loja = loja;
        }
    }
}