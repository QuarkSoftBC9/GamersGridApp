using GamersGridApp.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class AddOverwatchAccViewModel
    {
        private string region;
        public List<string> AccountRegionList { get; private set; }
        public string BattleTag { get; set; }
        public string Region
        {
            get
            {
                return region;
            }
            set
            {
                if (!AccountRegionList.Contains(value))
                   throw new ArgumentException("This region is non existent");
                this.region = value;
            }
        }



        public AddOverwatchAccViewModel()
        {
            AccountRegionList = new List<string>()
            {
                "us", "eu", "asia"
            };
        }

        public AddOverwatchAccViewModel(string name, string region)
        {
            AccountRegionList = new List<string>()
            {
                "us", "eu", "asia"
            };
            BattleTag = name ?? throw new ArgumentNullException("name is null");
            Region = region;
            
        }

        public string GetBattleTag()
        {
            if (String.IsNullOrEmpty(BattleTag))
                throw new ArgumentException("Name is not defined");
            return BattleTag.Replace("#", "-");
        }
    }
}