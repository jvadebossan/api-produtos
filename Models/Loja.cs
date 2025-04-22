
namespace MenuOn.Models
{
    public class Loja
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Email { get; set; }
        public virtual string ImagemUrl { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual IList<Usuario> Usuarios { get; set; } = [];

        public Loja()
        {
            DataCadastro = DateTime.Now;
        }
    }
}