using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutos.Infra.Maps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MySql.Data.MySqlClient;
using NHibernate;

namespace apiProdutos.Infra
{
    public class HibernateUtils
    {
        public static ISessionFactory sessionFactory;

        public static ISession GetSession()
        {
            sessionFactory = Fluently.Configure().Database(
                MySQLConfiguration.Standard.ConnectionString("Server=localhost;Port=3306;Database=nhibernate;Uid=root;Pwd=")
                .ShowSql()
                .FormatSql())
                .Mappings(
                    m => { m.FluentMappings.AddFromAssemblyOf<ClinteMap>(); }
                )
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}