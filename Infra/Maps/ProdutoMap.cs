using MenuOn.Models;
using FluentNHibernate.Mapping;

namespace MenuOn.Infra.Maps
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Schema("MENUON");
            Table("PRODUTO");
            Id(p => p.Id).Column("Id").Not.Nullable();
            Map(p => p.Nome).Column("Nome").Not.Nullable();
            Map(p => p.Descricao).Column("Descricao").Not.Nullable();
            Map(p => p.Preco).Column("Preco").Not.Nullable();
            Map(p => p.Disponivel).Column("Disponivel");
            Map(p => p.ImagemUrl).Column("Imagem_url");
            References(p => p.Categoria).Column("Id_categoria").Not.Nullable();
        }
    }
}