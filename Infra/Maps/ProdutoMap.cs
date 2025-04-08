using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutos2.Models;
using FluentNHibernate.Mapping;
using MySqlX.XDevAPI;

namespace apiProdutos2.Infra.Maps
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Schema("MENU_ON");
            Table("PRODUTO");
            Id(p => p.Id).Column("ID");
            Map(p => p.Nome).Column("NOME");
            Map(p => p.Preco).Column("PRECO");
        }
    }
}