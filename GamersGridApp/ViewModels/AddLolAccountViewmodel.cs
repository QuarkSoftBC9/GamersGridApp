using GamersGridApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersGridApp.Enums;

namespace GamersGridApp.ViewModels
{
    public class AddLOLAccountViewmodel
    {
        public List<string> AccountRegionsList { get; set; }

        public string Region { get; set; }
        public string UserName { get; set; }
        //public bool HasAccount { get; set; } = false;

        public AddLOLAccountViewmodel()
        {
            AccountRegionsList = new List<string>() //probably regions should be inserted in db since they are standard data that barelly ever change
            { 
                "BR1", "EUN1", "EUW1", "JP1","KR", "LA1", "LA2", "NA1", 
                "OC1", "RU", "TR1"
            };
        }
        public AddLOLAccountViewmodel(string name, string region)
        { 
            UserName = name ?? throw new ArgumentNullException("name is null");
            Region = region;
            AccountRegionsList = new List<string>()
            {
                "BR1", "EUN1", "EUW1", "JP1","KR", "LA1", "LA2", "NA1",
                "OC1", "RU", "TR1"
            };
        }
    }
}