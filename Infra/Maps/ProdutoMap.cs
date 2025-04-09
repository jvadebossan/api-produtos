using apiProdutos2.Models;
using FluentNHibernate.Mapping;

namespace apiProdutos2.Infra.Maps
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Schema("MENU_ON");
            Table("PRODUTO");
            Id(p => p.Id).Column("Id");
            Map(p => p.Nome).Column("Nome");
            Map(p => p.Descricao).Column("Descricao");
            Map(p => p.ImagemUrl).Column("Imagem_url");
            Map(p => p.Preco).Column("Preco");
            Map(p => p.Disponivel).Column("Disponivel");
            References(p => p.Categoria).Column("Id_categoria").Not.Nullable();
        }
    }
}