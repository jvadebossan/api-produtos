using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiProdutos2.Models
{
    public class Produto
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string ImagemUrl { get; set; }
        public virtual float Preco { get; set; }
        public virtual bool Disponivel { get; set; }
        public virtual Categoria Categoria { get; set; }

        public Produto(Categoria categoria)
        {
            this.Categoria = categoria;
        }
    }
}