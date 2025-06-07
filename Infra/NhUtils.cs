using MenuOn.Infra.Maps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using DotNetEnv;

namespace MenuOn.Infra
{
    public static class NhUtils
    {
        private static readonly ISessionFactory sessionFactory = Fluently.Configure()
            .Database(MySQLConfiguration.Standard.ConnectionString(Environment.GetEnvironmentVariable("DATABASE_URL"))
            .FormatSql().ShowSql())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProdutoMap>())
            .BuildSessionFactory();

        public static NHibernate.ISession GetSession() => sessionFactory.OpenSession();
    }
}