using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Dtos.ApiStatsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace GamersGridApp.WebServices
{
    public class DataService
    {
        public static LOLDto GetAccount(string url)
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var accountDto = (new JavaScriptSerializer()).Deserialize<LOLDto>(json);
                return accountDto;
            }
        }
        public static List<LOLStatsDto> GetStats(string url)
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var statsList = (new JavaScriptSerializer()).Deserialize<List<LOLStatsDto>>(json);
                return statsList;
            }
        }
        public static LOLMatchesListDto GetMatcheList(string url)
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var matches = (new JavaScriptSerializer()).Deserialize<LOLMatchesListDto>(json);
                return matches;
            }

        }
        public static List<LOLMatchesDto> GetMatches(string api, IEnumerable<object> matchIds)
        {
            List<LOLMatchesDto> matchesList = new List<LOLMatchesDto>();
            using (WebClient client = new WebClient())
            {
                foreach (var matchId in matchIds)
                {
                    var url = String.Format("https://eun1.api.riotgames.com/lol/match/v4/matches/{0}?api_key={1}", matchId, api);
                    string jsonMatch = client.DownloadString(url);
                    var rootAccountsMatch = (new JavaScriptSerializer()).Deserialize<LOLMatchesDto>(jsonMatch);
                    matchesList.Add(rootAccountsMatch);
                }
            }
            return matchesList;

        }
    }
}