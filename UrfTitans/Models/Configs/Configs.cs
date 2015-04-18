using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrfTitans.Models.Configs
{
    public class Configs
    {
        public static string apiKey = "yourapikey.";

        public static string urfMatches = "https://na.api.pvp.net/api/lol/na/v4.1/game/ids?beginDate=";

        public static string matchInfo = "https://na.api.pvp.net/api/lol/na/v2.2/match/";

        public static string champInfo = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion/";

        public static string champSkin = "?champData=skins";
    }
}