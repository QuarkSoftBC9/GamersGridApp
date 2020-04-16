using GamersGridApp.Dtos.ApiAcountsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace GamersGridApp.WebServices
{
    public class OverwatchDataService
    {
        //private string BattleTag { get; set; }
        //private string Region { get; set; }
        //private string ProfileUrl { get; set; }
        private string CompleteUrl { get; set; }
        private JavaScriptSerializer serializer;
        public OverwatchDataService(string battleTag, string region)
        {
            //BattleTag = battleTag;
            //Region = region;
            battleTag = BattleTagQueryFormatConversion(battleTag);
            //ProfileUrl = HttpUtility.UrlPathEncode($"https://ow-api.com/v1/stats/pc/{region}/{battleTag}/profile");
            CompleteUrl = HttpUtility.UrlPathEncode($"https://ow-api.com/v1/stats/pc/{region}/{battleTag}/complete");
            serializer = new JavaScriptSerializer();
        }

        //public OverWatchProfileDto GetProfileDto()
        //{
        //    using (WebClient client = new WebClient())
        //    {
        //        string json = client.DownloadString(ProfileUrl);
        //        return serializer.Deserialize<OverWatchProfileDto>(json);
        //    }
        //}

        public OverWatchCompleteDto GetCompleteProfileDto()
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(CompleteUrl);
                return serializer.Deserialize<OverWatchCompleteDto>(json);
            }
        }

        private static string BattleTagQueryFormatConversion(string battletag)
        {
            return battletag.Replace("#", "-");
        }

    }
}