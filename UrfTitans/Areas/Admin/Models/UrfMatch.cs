using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrfTitans.Areas.Admin.Models
{
    public class UrfMatch
    {
        public virtual int Id { get; set; }
        public virtual int MatchId { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual Boolean DataDownloaded { get; set; }
    }

    public class UrfMatchMap : ClassMapping<UrfMatch>
    {
        public UrfMatchMap()
        {
            Table("UrfMatches");

            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.MatchId, x => x.NotNullable(true));
            Property(x => x.DateCreated, x => x.NotNullable(true));
            Property(x => x.DataDownloaded, x => x.NotNullable(true));
        }
    }
}