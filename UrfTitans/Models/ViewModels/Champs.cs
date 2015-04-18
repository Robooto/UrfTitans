using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrfTitans.Models.ViewModels
{
    public class ChampsIndex
    {
        public IEnumerable<Champion> Champs { get; set; }
    }

    public class ShowChamp
    {
        public Champion Champ { get; set; }
    }

    public class GroupedChamp
    {
        public int champId { get; set; }
        public int count { get; set; }
        public int totalCount { get; set; }
    }

    public class GroupedChampIndex
    {
        public IEnumerable<GroupedChamp> GroupedChamps { get; set; }
    }
}