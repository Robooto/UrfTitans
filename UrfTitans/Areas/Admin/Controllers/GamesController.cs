using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using UrfTitans.Areas.Admin.Models.ViewModel;
using UrfTitans.Areas.Admin.Models;
using UrfTitans.Models;
using UrfTitans.Models.Configs;

namespace UrfTitans.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class GamesController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Epoch form)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(Configs.urfMatches + form.EpochTime.ToString() + "&" + Configs.apiKey);

                string content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    dynamic model = JsonConvert.DeserializeObject(content);
                    //SaveUrfMatches(model);
                    return View(model);
                }

                // an error occurred => here you could log the content returned by the remote server
                return Content("An error occurred: " + content);
            }
        }

        public async Task<ActionResult> UrfMatch(int matchId)
        {

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(Configs.matchInfo + matchId.ToString() + "?" + Configs.apiKey).Result;

                string content = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    RootObject model = JsonConvert.DeserializeObject<RootObject>(content);

                    foreach (var item in model.participants)
                    {
                        var champ = new Champion();
                        champ.MatchId = model.matchId;
                        champ.ChampionId = item.championId;
                        champ.winner = model.teams.Where(x => x.teamId == item.teamId).Select(x => x.winner).Single();
                        Database.Session.Save(champ);

                    }

                    foreach (var item in model.teams)
                    {
                        foreach (var ban in item.bans)
                        {
                            var bannedchamp = new BannedChamp();
                            bannedchamp.MatchId = model.matchId;
                            bannedchamp.BannedChampionId = ban.championId;
                            bannedchamp.winner = item.winner;
                            Database.Session.Save(bannedchamp);
                        }
                    }

                    UrfMatch match = Database.Session.Query<UrfMatch>().Where(x => x.MatchId == matchId).Single();
                    var updateMatch = Database.Session.Load<UrfMatch>(match.Id);
                    updateMatch.DataDownloaded = true;
                    Database.Session.Update(updateMatch);
                    Database.Session.Flush();

                    return View(model);
                }

                // an error occurred => here you could log the content returned by the remote server
                return Content("An error occurred: " + content);
            }

        }
    }
}