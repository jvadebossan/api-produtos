using MenuOn.Models;
using FluentNHibernate.Mapping;

namespace MenuOn.Infra.Maps
{
    public class MenuMap : ClassMap<Menu>
    {
        public MenuMap()
        {
            Schema("MENUON");
            Table("MENU");
            Id(p => p.Id).Column("Id").Not.Nullable();
            Map(p => p.Nome).Column("Nome").Not.Nullable();
            Map(p => p.Descricao).Column("Descricao").Not.Nullable();
            Map(p => p.Ativo).Column("Ativo");
            References(p => p.Loja).Column("Id_loja").Not.Nullable();
            HasMany(p => p.Categorias).KeyColumn("Id_menu").Inverse().Cascade.All();
        }
    }
}