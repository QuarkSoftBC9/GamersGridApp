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
        public static LOLDto GetAccount(string region, string nickname, string api)
        {
            string urlAccount = String.Format("https://{0}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{1}?api_key={2}",region, nickname
                , api);
            urlAccount = HttpUtility.UrlPathEncode(urlAccount);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(urlAccount);
                var accountDto = (new JavaScriptSerializer()).Deserialize<LOLDto>(json);
                return accountDto;
            }
        }
        public static List<LOLStatsDto> GetStats(string region, string accIdentifier, string api)
        {
            var urlStats = String.Format("https://{0}.api.riotgames.com/lol/league/v4/entries/by-summoner/{1}?api_key={2}",
                region, accIdentifier, api);
            urlStats = HttpUtility.UrlPathEncode(urlStats);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(urlStats);
                var statsList = (new JavaScriptSerializer()).Deserialize<List<LOLStatsDto>>(json);
                return statsList;
            }
        }
        public static LOLMatchesListDto GetMatcheList(string identifier2, string api, int startIndex = 0, int endIndex = 9)
        {
            var urlMatchesList = String.Format("https://eun1.api.riotgames.com/lol/match/v4/matchlists/by-account/{0}?endIndex={1}&beginIndex={2}&api_key={3}",
                identifier2,endIndex, startIndex, api);
            urlMatchesList = HttpUtility.UrlPathEncode(urlMatchesList);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(urlMatchesList);
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