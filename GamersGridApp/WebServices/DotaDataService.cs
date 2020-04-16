using GamersGridApp.Dtos.ApiAcountsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace GamersGridApp.WebServices
{
    public class DotaDataService 
    {
        private string SteamId { get; set; }
        private string UrlAccount { get; set; }
        private string UrlWinsLoses { get; set; }
        private string UrlRecentMatches { get; set; }
        private JavaScriptSerializer serializer;
        public DotaDataService(string steamCommunityId)
        {
            SteamId = ConvertCommunityIdToSteamID(steamCommunityId);
            UrlAccount = HttpUtility.UrlPathEncode($"https://api.opendota.com/api/players/{SteamId}");
            UrlWinsLoses = HttpUtility.UrlPathEncode($"https://api.opendota.com/api/players/{SteamId}/wl");
            UrlRecentMatches = HttpUtility.UrlPathEncode($"https://api.opendota.com/api/players/{SteamId}/recentMatches");
            serializer = new JavaScriptSerializer();
        }
        public DotaDto GetAccountDto()
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(UrlAccount);
                DotaDto dotaAccountDto = serializer.Deserialize<DotaDto>(json);

                if (dotaAccountDto.profile == null)
                    throw new NullReferenceException();
                else
                    return dotaAccountDto;
            }
        }

        public DotaWinsLosesDto GetWLDto()
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(UrlWinsLoses);
                return serializer.Deserialize<DotaWinsLosesDto>(json);
            }
        }

        public List<DotaMatchDto> GetMatches()
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(UrlRecentMatches);
                return serializer.Deserialize<List<DotaMatchDto>>(json);
            }
        }

        private static string ConvertCommunityIdToSteamID(string communityId)
        {
            var steamcommunityId = Int64.Parse(communityId);
            var steamId = (steamcommunityId - (76561197960265728 + (76561197960265728 % 2)));
            return Convert.ToString(steamId);
        }


    }
}