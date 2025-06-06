using MenuOn.Models;
using FluentNHibernate.Mapping;

namespace MenuOn.Infra.Maps
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Schema("MENUON");
            Table("USUARIO");
            Id(x => x.Id).Column("Id");
            Map(x => x.Nome).Column("Nome");
            Map(x => x.Email).Column("Email");
            Map(x => x.Senha).Column("Senha");
            Map(x => x.Cargo).Column("Cargo");
            Map(x => x.DataCadastro).Column("Data_cadastro");
            HasManyToMany(x => x.Lojas)
                .Table("USUARIO_LOJA")
                .ParentKeyColumn("ID_USUARIO")
                .ChildKeyColumn("ID_LOJA")
                .Cascade.All();
        }
    }
}