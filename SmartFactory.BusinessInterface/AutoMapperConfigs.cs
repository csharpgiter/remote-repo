using AutoMapper;
using SmartFactory.Entity.EntityMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartFactory.Common.Result;

namespace SmartFactory.BusinessInterface
{
    public class AutoMapperConfigs:Profile
    {
        public AutoMapperConfigs()
        {
            CreateMap<SystemLog,SystemLogDto>().ReverseMap();
            CreateMap<PagingData<SystemLog>, PagingData<SystemLogDto>>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<PagingData<User>, PagingData<UserDto>>().ReverseMap();
        }
    }
}
