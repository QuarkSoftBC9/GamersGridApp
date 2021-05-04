using GamersGrid.Services.GameAPIs.Overwatch.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.Services.GameAPIs.Overwatch
{
    public class OverwatchService
    {
        public HttpClient Client { get; set; }


        public OverwatchService(IHttpClientFactory clientFactory)
        {
            Client = clientFactory.CreateClient();
        }


        public async Task<StatisticsResult> GetCompleteProfileDto(string battleTag, string region)
        {
            battleTag = BattleTagQueryFormatConversion(battleTag);

            var requestUrl = $"https://ow-api.com/v1/stats/pc/{region}/{battleTag}/complete";
            var responseMessage = await Client.GetAsync(requestUrl);
            var messageBody = await responseMessage.Content.ReadAsStringAsync();

            var completeDto = JsonConvert.DeserializeObject<OverWatchCompleteDTO>(messageBody);


            return StatisticsResult.From(completeDto);
        }


        private string BattleTagQueryFormatConversion(string battletag)
        {
            return battletag.Replace("#", "-");
        }
    }
}
