﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersGridApp.Models;
using GamersGridApp.Dtos;
using GamersGridApp.Models.GameAccounts;
using GamersGridApp.Dtos.ApiAcountsDtos;

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

            CreateMap<LOLDto, AccountLOL>();
            CreateMap<AccountLOL, LOLDto>();
        }
    }
}