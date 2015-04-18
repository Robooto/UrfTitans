using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrfTitans.Models
{
    public class Champion 
    {
        public virtual int Id { get; set; }
        public virtual int MatchId { get; set; }
        public virtual int ChampionId { get; set; }
        public virtual bool winner { get; set; }
    }

    public class ChampionMap : ClassMapping<Champion>
    {
        public ChampionMap() 
        {
            Table("champions");

            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.MatchId, x => x.NotNullable(true));
            Property(x => x.ChampionId, x => x.NotNullable(true));
            Property(x => x.winner, x => x.NotNullable(true));
        }
    }
}