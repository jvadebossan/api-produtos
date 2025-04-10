using apiProdutos2.Infra.Maps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace apiProdutos2.Infra
{
    public class NhUtils
    {
        public static ISessionFactory sessionFactory;

        public static NHibernate.ISession GetSession()
        {
            sessionFactory = Fluently.Configure().Database(
                MySQLConfiguration.Standard.ConnectionString("Server=localhost;Port=3306;Database=menu_on;Uid=root;Pwd=")
                //.ShowSql()
                .FormatSql())
                .Mappings(
                    m => { m.FluentMappings.AddFromAssemblyOf<ProdutoMap>(); }
                )
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}