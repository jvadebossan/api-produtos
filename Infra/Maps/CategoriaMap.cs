using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutos2.Models;
using FluentNHibernate.Mapping;
using MySqlX.XDevAPI;

namespace apiProdutos2.Infra.Maps
{
    public class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Schema("MENU_ON");
            Table("CATEGORIA");
            Id(p => p.Id).Column("Id");
            Map(p => p.Nome).Column("Nome");
            Map(p => p.Descricao).Column("Descricao");
            Map(p => p.OrdemExibicao).Column("Ordem_exibicao");
            Map(p => p.ImagemUrl).Column("Imagem_url");
            Map(p => p.Ativo).Column("Ativo");
            HasMany(p => p.Produtos).KeyColumn("Id_categoria").Inverse().Cascade.All();
            References(p => p.Menu).Column("Id_menu").Not.Nullable();
        }
    }
}