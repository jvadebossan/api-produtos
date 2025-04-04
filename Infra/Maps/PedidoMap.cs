using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutos.Entities;
using FluentNHibernate.Mapping;

namespace apiProdutos.Infra.Maps
{
    public class PedidoMap : ClassMap<Pedido>
    {
        public PedidoMap()
        {
            Schema("nhibernate");
            Table("PEDIDO");
            Id(p => p.Id).Column("ID");
            Map(p => p.DataPedido).Column("DATAPEDIDO");
            References(p => p.Cliente).Column("IDCLIENTE");
            HasManyToMany(p => p.Produtos)
                .Table("ITEMPRODUTO")
                .ParentKeyColumn("IDPEDIDO")
                .ChildKeyColumn("IDPRODUTO")
            .Cascade.All();
        }
    }
}