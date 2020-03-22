using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersGridApp.Models;
using GamersGridApp.Dtos;
using GamersGridApp.Models.GameAccounts;
using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Dtos.ApiStatsDto;

namespace GamersGridApp.App_Start
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<LOLDto, LOLAccount>();
            CreateMap<LOLAccount, LOLDto>();

            CreateMap<LOLStatsDto, LOLAccount>();
            CreateMap<LOLAccount, LOLStatsDto>();
        }
    }
}