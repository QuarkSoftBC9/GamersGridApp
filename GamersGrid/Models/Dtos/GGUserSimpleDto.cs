using GamersGrid.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Models.Dtos
{
    public class GGUserSimpleDto
    {
        public string NickName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }



        public static GGUserSimpleDto CreateFromUser(GGuser user)
        {
            return new GGUserSimpleDto()
            {
                NickName = user.NickName,
                Country = user.Country,
                City = user.City
            };
        }
    }
}
