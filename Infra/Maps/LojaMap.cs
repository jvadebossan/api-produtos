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
            Id(p => p.Id).Column("Id").Not.Nullable();
            Map(p => p.Nome).Column("Nome").Not.Nullable();
            Map(p => p.Endereco).Column("Endereco").Not.Nullable();
            Map(p => p.Telefone).Column("Telefone");
            Map(p => p.Email).Column("Email");
            Map(p => p.ImagemUrl).Column("Imagem_url").Not.Nullable();
            Map(p => p.DataCadastro).Column("Data_cadastro");
            HasOne(x => x.Menu)
            .PropertyRef(m => m.Loja) // referência à propriedade Loja dentro de Menu
            .Cascade.All()
            .LazyLoad(); // opcional: remova para eager loading
            HasManyToMany(x => x.Usuarios)
            .Table("USUARIO_LOJA")
            .ParentKeyColumn("ID_LOJA")
            .ChildKeyColumn("ID_USUARIO")
            .Cascade.All()
            .Inverse();
        }
    }
}