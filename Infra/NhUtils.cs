using apiProdutos2.Infra.Maps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using DotNetEnv;

namespace apiProdutos2.Infra
{
    public class NhUtils
    {
        public static ISessionFactory sessionFactory;

        public static NHibernate.ISession GetSession()
        {
            sessionFactory = Fluently.Configure().Database(
                MySQLConfiguration.Standard.ConnectionString(Environment.GetEnvironmentVariable("DATABASE_URL"))
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