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
        }
    }
}