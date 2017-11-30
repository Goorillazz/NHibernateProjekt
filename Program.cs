using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping;
using NHibernateProjekt.Data;

namespace NHibernateProjekt
{
    class Program
    {
        static void Main(string[] args)
        {

            bool exit = false;
            while (!exit)
            {

                Console.WriteLine("Please choose example. Component 'c' or Subclass 's'");
                Console.WriteLine("Exit 'e'");

                var answer = Console.ReadLine();

                switch (answer)
                {
                    case "c":
                        Component();
                        break;
                    case "s":
                        Subclass();
                        break;
                    case "e":
                    exit = true;
                        break;
                        
                }                
            }

        }

        private static void Component()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var bewohner = new Bewohner()
                    {
                        Name = "Chris"
                    };

                    var haus = new Haus()
                    {
                        Hausnummer = 1,
                        Hausbewohner = bewohner
                    };

                    var strasse = new Strasse()
                    {
                        PLZ = 4711,
                        Häuser = haus,
                        Reiniger = bewohner
                    };

                    var strasseMitComponenten = new StrasseMitComponenten()
                    {
                        PLZ = 4712,
                        Häuser = haus,
                        Reiniger = bewohner
                    };

                    session.Save(strasse);
                    session.Save(strasseMitComponenten);
                    transaction.Commit();

                    Console.WriteLine("Done!");
                }
            }
        }

        private static void Subclass()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var parentA = new ParentA()
                    {
                        Name = "Chris"
                    };

                    var childA = new ChildA()
                    {
                        Name = "Mary",
                        AnotherProperty = "Likes dogs"
                    }; 

                    var parentB = new ParentB()
                    {
                        Name = "Chris"
                    };

                    var childB = new ChildB()
                    {
                        Name = "Mary",
                        AnotherProperty = "Likes dogs"
                    }; 
                    
                    var parentC = new ParentC()
                    {
                        Name = "Chris"
                    };

                    var childC = new ChildC()
                    {
                        Name = "Mary",
                        AnotherProperty = "Likes dogs"
                    }; 

                    session.Save(parentA);
                    session.Save(parentB);
                    session.Save(parentC);
                    session.Save(childA);
                    session.Save(childB);
                    session.Save(childC);
                    
                    transaction.Commit();

                    Console.WriteLine("Done!");
                }
            }
        }
    }
}
