using MenuOn.Models;
using FluentNHibernate.Mapping;

namespace MenuOn.Infra.Maps
{
    public class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Schema("MENU_ON");
            Table("CATEGORIA");
            Id(p => p.Id).Column("Id").Not.Nullable();
            Map(p => p.Nome).Column("Nome").Not.Nullable();
            Map(p => p.Descricao).Column("Descricao").Not.Nullable();
            Map(p => p.OrdemExibicao).Column("Ordem_exibicao").Not.Nullable();
            Map(p => p.ImagemUrl).Column("Imagem_url");
            Map(p => p.Ativo).Column("Ativo");
            HasMany(p => p.Produtos).KeyColumn("Id_categoria").Inverse().Cascade.All();
            References(p => p.Menu).Column("Id_menu").Not.Nullable();
        }
    }
}