using GamersGridApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class AddLOLAccountViewmodel
    {
        public List<LoLRegions> LolRegions { get; set; }

        public LoLRegions Region { get; set; }
        public string UserName { get; set; }

        public AddLOLAccountViewmodel()
        {
            LolRegions = new List<LoLRegions>() 
            { LoLRegions.BR1, LoLRegions.EUN1, LoLRegions.EUW1, LoLRegions.JP1, 
              LoLRegions.KR, LoLRegions.LA1, LoLRegions.LA2, LoLRegions.NA1, 
              LoLRegions.OC1, LoLRegions.RU, LoLRegions .TR1};
        }
    }
}