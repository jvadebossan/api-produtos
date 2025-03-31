using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutos.Entities;
using FluentNHibernate.Mapping;
using MySqlX.XDevAPI;

namespace apiProdutos.Infra.Maps
{
    public class ClinteMap : ClassMap<Cliente>
    {
        public ClinteMap()
        {
            Schema("APIPRODUTOS");
            Table("");
            Id(cliente => cliente.Id).Column("Id");
        }
    }
}