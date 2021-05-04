using GamersGrid.Services.GameAPIs.Dota.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.Services.GameAPIs.Dota
{
    public class DotaService
    {
        public HttpClient Client { get; set; }

        private string ApiKey { get; set; }

        public DotaService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            Client = clientFactory.CreateClient();
            ApiKey = configuration.GetSection("DotaApiKey").Value;
        }



        public async Task<DotaDTO> GetAccountDto(string steamId)
        {

            string accountRequestURL = $"https://api.opendota.com/api/players/{steamId}";
            var response = await Client.GetAsync(accountRequestURL);
            var responseBody = await response.Content.ReadAsStringAsync();

            DotaDTO dotaDTO = JsonConvert.DeserializeObject<DotaDTO>(responseBody);

            return dotaDTO;
        }

        public async Task<DotaWinsLosesDTO> GetWLDto(string steamId)
        {
            string accountRequestURL = $"https://api.opendota.com/api/players/{steamId}/wl";
            var response = await Client.GetAsync(accountRequestURL);
            var responseBody = await response.Content.ReadAsStringAsync();

            DotaWinsLosesDTO dotaDTO = JsonConvert.DeserializeObject<DotaWinsLosesDTO>(responseBody);

            return dotaDTO;
        }

        public async Task<List<DotaMatchDTO>> GetMatches(string steamId)
        {
            string accountRequestURL = $"https://api.opendota.com/api/players/{steamId}/recentMatches";
            var response = await Client.GetAsync(accountRequestURL);
            var responseBody = await response.Content.ReadAsStringAsync();

            List<DotaMatchDTO> dotaDTO = JsonConvert.DeserializeObject<List<DotaMatchDTO>>(responseBody);

            return dotaDTO;
        }
        public  string ConvertCommunityIdToSteamID(string communityId)
        {
            var steamcommunityId = Int64.Parse(communityId);
            var steamId = (steamcommunityId - (76561197960265728 + (76561197960265728 % 2)));
            return Convert.ToString(steamId);
        }

        public double CalculateKda(List<DotaMatchDTO> matches)
        {
            int KillsAssists = 0;
            int deaths = 0;

            foreach (var dotaMatch in matches)
            {
                KillsAssists += dotaMatch.kills + dotaMatch.assists;
                deaths += dotaMatch.deaths;
            }
            if (deaths == 0)
                return KillsAssists;

            var result = Math.Round((double)KillsAssists / deaths, 2);
            return result;
        }

    }
}
