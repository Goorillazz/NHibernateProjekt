using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace NHibernateProjekt.Data
{
    public class Data
    {
    }

    public class Bewohner
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

    }

    public class Haus
    {
        public virtual int Id { get; set; }
        public virtual int Hausnummer { get; set; }

        public virtual Bewohner Hausbewohner { get; set; }

    }

    public class Strasse
    {
        public virtual int Id { get; set; }
        public virtual int PLZ { get; set; }

        public virtual Haus Häuser { get; set; }

        public virtual Bewohner Reiniger { get; set; }

    }

    public class StrasseMitComponenten
    {
        public virtual int Id { get; set; }
        public virtual int PLZ { get; set; }

        public virtual Haus Häuser { get; set; }

        public virtual Bewohner Reiniger { get; set; }

    }
    
    public class ParentA
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class ChildA : ParentA
    {
        public virtual string AnotherProperty { get; set; }
    }

    public class ParentB
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class ChildB : ParentB
    {
        public virtual string AnotherProperty { get; set; }
    }

    public class ParentC
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class ChildC : ParentC
    {
        public virtual string AnotherProperty { get; set; }
    }

}
