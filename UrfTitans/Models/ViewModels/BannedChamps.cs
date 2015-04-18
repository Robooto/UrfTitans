using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrfTitans.Models.ViewModels
{
    public class BannedChampsIndex
    {
        public IEnumerable<BannedChamp> BannedChamps { get; set; }
    }

    public class BannedChampShow
    {
        public BannedChamp BannedChamp { get; set; }
    }

    public class BannedGroupedChamp
    {
        public int champId { get; set; }
        public int count { get; set; }
        public int totalCount { get; set; }
    }

    public class BannedGroupedChampIndex
    {
        public IEnumerable<GroupedChamp> GroupedChamps { get; set; }
    }
}