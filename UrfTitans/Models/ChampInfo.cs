using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrfTitans.Models
{
    public class ChampInfo
    {
        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public List<Skin> skins { get; set; }
        public string key { get; set; }
    }

    public class Skin
    {
        public int id { get; set; }
        public int num { get; set; }
        public string name { get; set; }
    }
}