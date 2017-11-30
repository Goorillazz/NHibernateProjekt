using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernateProjekt.Data;

namespace NHibernateProjekt
{
    public class NHibernateHelper
    {

        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            var buildConfiguration = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(@"Data Source=DEHAMPWW0011;Initial Catalog=NHibernateDB;Integrated Security=True;")
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Haus>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true)).BuildConfiguration();
            _sessionFactory = buildConfiguration.BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }


    }
}
