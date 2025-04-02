using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiProdutos.Entities
{
    public class Pedido
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataPedido { get; set; }
        public virtual Cliente Cliente { get; set; }

        public Pedido() { }

        public Pedido(Cliente cliente)
        {
            DataPedido = DateTime.Now;
            Cliente = cliente;
        }
    }
}