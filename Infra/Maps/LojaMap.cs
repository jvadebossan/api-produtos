using apiProdutos2.Models;
using FluentNHibernate.Mapping;

namespace apiProdutos2.Infra.Maps
{
    public class LojaMap : ClassMap<Loja>
    {
        public LojaMap()
        {
            Schema("MENU_ON");
            Table("LOJA");
            Id(p => p.Id).Column("Id");
            Map(p => p.Nome).Column("Nome");
            Map(p => p.Endereco).Column("Endereco");
            Map(p => p.Telefone).Column("Telefone");
            Map(p => p.Email).Column("Email");
            Map(p => p.ImagemUrl).Column("Imagem_url");
            Map(p => p.DataCadastro).Column("Data_cadastro");
            HasOne(x => x.Menu)
            .PropertyRef(m => m.Loja) // referência à propriedade Loja dentro de Menu
            .Cascade.All()
            .LazyLoad(); // opcional: remova se quiser eager loading
            //HasMany(p => p.Menus).KeyColumn("Id_loja").Inverse().Cascade.All();
        }
    }
}