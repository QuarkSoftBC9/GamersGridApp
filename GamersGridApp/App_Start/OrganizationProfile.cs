using AutoMapper;

using GamersGridApp.Core.Dtos;
using GamersGridApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



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

            //CreateMap<Notification, NotificationDto>();
            //CreateMap<NotificationDto, Notification>();

            //CreateMap<LOLDto, LOLAccount>();
            //CreateMap<LOLAccount, LOLDto>();

            //CreateMap<LOLStatsDto, LOLAccount>();
            //CreateMap<LOLAccount, LOLStatsDto>();
        }
    }
}