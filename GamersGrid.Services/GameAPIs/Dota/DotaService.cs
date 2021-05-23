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


        public string GetDota2RankIcon(string rank)
        {
            int rankInt= int.Parse(rank);

            var rankString = rankInt > 5420 ? "Divine5.png" :
                rankInt > 5420 ? "Divine4.png" :
                rankInt > 5220 ? "Divine3.png" :
                rankInt > 5020 ? "Divine2.png" :
                rankInt > 4820 ? "Divine1.png" :
                rankInt > 4620 ? "Ancient5.png" :
                rankInt > 4466 ? "Ancient4.png" :
                rankInt > 4312 ? "Ancient3.png" :
                rankInt > 4158 ? "Ancient2.png" :
                rankInt > 4004 ? "Ancient1.png" :
                rankInt > 3850 ? "Legend5.png" :
                rankInt > 3696 ? "Legend4.png" :
                rankInt > 3542 ? "Legend3.png" :
                rankInt > 3388 ? "Legend2.png" :
                rankInt > 3234 ? "Legend1.png" :
                rankInt > 3080 ? "Archon5.png" :
                rankInt > 2926 ? "Archon4.png" :
                rankInt > 2618 ? "Archon3.png" :
                rankInt > 2464 ? "Archon2.png" :
                rankInt > 2310 ? "Archon1.png" :
                rankInt > 2156 ? "Crusader5.png" :
                rankInt > 2002 ? "Crusader4.png" :
                rankInt > 1848 ? "Crusader3.png" :
                rankInt > 1694 ? "Crusader2.png" :
                rankInt > 1540 ? "Crusader1.png" :
                rankInt > 1386 ? "Guardian5.png" :
                rankInt > 1232 ? "Guardian4.png" :
                rankInt > 1078 ? "Guardian3.png" :
                rankInt > 924 ? "Guardian2.png" :
                rankInt > 770 ? "Guardian1.png" :
                rankInt > 616 ? "Herald5.png" :
                rankInt > 462 ? "Herald4.png" :
                rankInt > 308 ? "Herald3.png" :
                rankInt > 154 ? "Herald2.png" :
                 "Herald1.png";
            return rankString;
        }

    }
}
