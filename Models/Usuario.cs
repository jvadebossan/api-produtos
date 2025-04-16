
using System.Text.Json.Serialization;

namespace apiProdutos2.Models
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Cargo { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        [JsonIgnore]
        public virtual IList<Loja> Lojas { get; set; } = [];
    }
}