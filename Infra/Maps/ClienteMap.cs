using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutos.Entities;
using FluentNHibernate.Mapping;
using MySqlX.XDevAPI;

namespace apiProdutos.Infra.Maps
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Schema("nhibernate");
            Table("CLIENTE");
            Id(cliente => cliente.Id).Column("ID");
            Map(cliente => cliente.Nome).Column("NOME");
            Map(cliente => cliente.Email).Column("EMAIL");
            Map(cliente => cliente.Senha).Column("SENHA");
            HasMany(cliente => cliente.Pedidos).KeyColumn("IDCLIENTE");
        }
    }
}