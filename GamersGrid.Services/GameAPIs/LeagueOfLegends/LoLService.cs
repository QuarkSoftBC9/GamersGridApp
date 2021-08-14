using GamersGrid.Services.GameAPIs.LeagueOfLegends.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.Services.GameAPIs.LeagueOfLegends
{
    public class LoLService
    {
        public HttpClient Client { get; set; }

        private string ApiKey { get; set; }

        public LoLService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            Client = clientFactory.CreateClient();
            ApiKey = configuration.GetSection("LoLApiKey").Value;
        }

        public async Task<LoLDTO> GetAccount(string region, string nickname)
        {
            string requestUrl = $"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{nickname}?api_key={ApiKey}";
            var response = await Client.GetAsync(requestUrl);
            var responseBody = await response.Content.ReadAsStringAsync();

            var lolDto = JsonConvert.DeserializeObject<LoLDTO>(responseBody);

            return lolDto;
        }


        public async Task<List<LoLStatsDTO>> GetStats(string region, string accIdentifier)
        {
            var requestUrl = $"https://{region}.api.riotgames.com/lol/league/v4/entries/by-summoner/{accIdentifier}?api_key={ApiKey}";
            var response = await Client.GetAsync(requestUrl);
            var responseBody = await response.Content.ReadAsStringAsync();

            List<LoLStatsDTO> statsList = JsonConvert.DeserializeObject<List<LoLStatsDTO>>(responseBody);
            return statsList;
        }

        public async Task<LoLMatchesListDTO> GetMatcheList(string identifier2, int startIndex = 0, int endIndex = 9)
        {
            string requestUrl = $"https://eun1.api.riotgames.com/lol/match/v4/matchlists/by-account/{identifier2}?endIndex={endIndex}&beginIndex={startIndex}&api_key={ApiKey}";
            var response = await Client.GetAsync(requestUrl);
            var responseBody = await response.Content.ReadAsStringAsync();

            LoLMatchesListDTO matchesList = JsonConvert.DeserializeObject<LoLMatchesListDTO>(responseBody);
            return matchesList;
        }
        public async Task<List<LoLMatchesDTO>> GetMatches( IEnumerable<object> matchIds)
        {

            List<LoLMatchesDTO> matchesList = new List<LoLMatchesDTO>();

            foreach (var matchId in matchIds)
            {
                string requestUrl = $"https://eun1.api.riotgames.com/lol/match/v4/matches/{matchId}?api_key={ApiKey}";
                var response = await Client.GetAsync(requestUrl);
                var responseBody = await response.Content.ReadAsStringAsync();

                matchesList.Add(JsonConvert.DeserializeObject<LoLMatchesDTO>(responseBody));
            }

            return matchesList;

        }

        public string CalculateKDA(List<LoLMatchesDTO> listOfMatches, string accountId)
        {
            //some defensive programming should be added for values
            var kda = new List<double>();
            for (int i = 0, let = listOfMatches.Count; i < let; i++)
            {
                int playerId = listOfMatches[0].participantIdentities
                .Where(p => p.player.accountId == accountId)
                .Select(p => p.participantId).SingleOrDefault();

                kda.Add(GetKDA(listOfMatches[i], playerId));
            }
            var average = kda.Average();
            return  average.ToString("0.00");
        }
        public double GetKDA(LoLMatchesDTO match, int playerID)
        {
            int kills = match.participants
                .Where(p => p.participantId == playerID)
                .Select(p => p.stats.kills)
                .SingleOrDefault();
            int deaths = match.participants
                .Where(p => p.participantId == playerID)
                .Select(p => p.stats.deaths)
                .SingleOrDefault();
            int assists = match.participants
                .Where(p => p.participantId == playerID)
                .Select(p => p.stats.assists)
                .SingleOrDefault();
            if (deaths == 0)
                return (double)kills + (double)assists;
            return ((double)kills + (double)assists) / (double)deaths;
        }
    }
}
