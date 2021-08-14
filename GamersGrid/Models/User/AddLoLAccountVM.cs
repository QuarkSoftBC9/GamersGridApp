using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Models.User
{
    public class AddLoLAccountVM
    {
        public List<string> AccountRegionsList { get; set; }
        public string Region { get; set; }
        public string UserName { get; set; }
        public bool HasAccount { get; set; }

        public AddLoLAccountVM()
        {
            AccountRegionsList = new List<string>()
            {
                "BR1", "EUN1", "EUW1", "JP1","KR", "LA1", "LA2", "NA1",
                "OC1", "RU", "TR1"
            };
        }
    }
}
