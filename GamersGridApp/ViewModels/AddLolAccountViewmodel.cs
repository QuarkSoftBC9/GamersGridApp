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
        public List<AccountRegions> AccountRegionsList { get; set; }

        public AccountRegions Region { get; set; }
        public string UserName { get; set; }
        //public bool HasAccount { get; set; } = false;

        public AddLOLAccountViewmodel()
        {
            AccountRegionsList = new List<AccountRegions>() 
            { 
                AccountRegions.BR1, AccountRegions.EUN1, AccountRegions.EUW1, AccountRegions.JP1, 
                AccountRegions.KR, AccountRegions.LA1, AccountRegions.LA2, AccountRegions.NA1, 
                AccountRegions.OC1, AccountRegions.RU, AccountRegions.TR1
            };
        }
        public AddLOLAccountViewmodel(string name, AccountRegions region)
        { 
            UserName = name ?? throw new ArgumentNullException("name is null");
            Region = region;
            //HasAccount = true;

            AccountRegionsList = new List<AccountRegions>()
            { AccountRegions.BR1, AccountRegions.EUN1, AccountRegions.EUW1, AccountRegions.JP1,
              AccountRegions.KR, AccountRegions.LA1, AccountRegions.LA2, AccountRegions.NA1,
              AccountRegions.OC1, AccountRegions.RU, AccountRegions .TR1};
        }
    }
}