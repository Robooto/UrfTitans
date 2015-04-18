using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using System.Web;
using System.Web.Mvc;
using UrfTitans.Models;
using UrfTitans.Models.ViewModels;
using UrfTitans.Models.Configs;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace UrfTitans.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MostPlayed()
        {
            var total = Database.Session.Query<Champion>().Select(x => x.MatchId).Distinct().Count();
            var Query = Database.Session.Query<Champion>()
                                    .GroupBy(champ => champ.ChampionId)
                                    .Select(x => new GroupedChamp
                                    {
                                        champId = x.Key,
                                        count = x.Count(),
                                        totalCount = total
                                    })
                                    .OrderByDescending(o => o.count)
                                    .Take(5).ToList();

            return View(Query);
        }

        [ChildActionOnly]
        public ActionResult MostBanned()
        {
            var total = Database.Session.Query<BannedChamp>().Select(x => x.MatchId).Distinct().Count();
            var Query = Database.Session.Query<BannedChamp>()
                                    .GroupBy(champ => champ.BannedChampionId)
                                    .Select(x => new BannedGroupedChamp
                                    {
                                        champId = x.Key,
                                        count = x.Count(),
                                        totalCount = total
                                    })
                                    .OrderByDescending(o => o.count)
                                    .Take(5).ToList();

            return View(Query);
        }

        [ChildActionOnly]
        public async Task<ActionResult> Champ(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(Configs.champInfo + id.ToString() + Configs.champSkin + "&" + Configs.apiKey).Result;

                string content = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    var model = JsonConvert.DeserializeObject<ChampInfo>(content);
                    return View(model);
                }

                // an error occurred => here you could log the content returned by the remote server
                return Content("An error occurred: " + content);

            }
        }
    }
}