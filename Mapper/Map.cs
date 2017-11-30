using System.Security.Cryptography.X509Certificates;
using FluentNHibernate.Mapping;

namespace NHibernateProjekt.Data
{
    public class BewohnerMap : ClassMap<Bewohner>
    {
        public BewohnerMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }

    public class HausMap : ClassMap<Haus>
    {
        public HausMap()
        {
            Id(x => x.Id);
            Map(x => x.Hausnummer);
            References(x => x.Hausbewohner).Cascade.All();
        }
    }
    

    public class StrasseMap : ClassMap<Strasse>
    {

        public StrasseMap()
        {
            Id(x => x.Id);
            Map(x => x.PLZ);
            References(x => x.Häuser).Cascade.All();
            References(x => x.Reiniger).Cascade.All();
        }
    }

    public class StrasseMitComponentenMap : ClassMap<StrasseMitComponenten>
    {

        public StrasseMitComponentenMap()
        {
            Id(x => x.Id);
            Map(x => x.PLZ);
            Component(x => x.Häuser, m =>
            {
                m.Map(x => x.Hausnummer);
                m.References(x => x.Hausbewohner).Cascade.All();
            });
            Component(x => x.Reiniger, m =>
            {
                m.Map(x => x.Name);
            });
        }
    }

    public class ParentAMap : ClassMap<ParentA>
    {
        public ParentAMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }

    public class ChildAMap : SubclassMap<ChildA>
    {
        public ChildAMap()
        {
            Map(x => x.AnotherProperty);
        }
    }

    public class ParentBMap : ClassMap<ParentB>
    {
        public ParentBMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);

            DiscriminateSubClassesOnColumn("type");
        }
    }

    public class ChildBMap : SubclassMap<ChildB>
    {
        public ChildBMap()
        {
            DiscriminatorValue("Child B");
            Map(x => x.AnotherProperty);
        }
    }

    public class ParentCMap : ClassMap<ParentC>
    {
        public ParentCMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            
        }
    }

    public class ChildCMap : SubclassMap<ChildC>
    {
        public ChildCMap()
        {
            DiscriminatorValue("Child C");
            Map(x => x.AnotherProperty);
        }
    }
}