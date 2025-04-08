using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiProdutos2.Models
{
    public class Menu
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool Ativo { get; set; }
        public virtual Loja Loja { get; set; }

        public Menu() { }
        
        public Menu(Loja loja)
        {
            Loja = loja;
        }
    }
}