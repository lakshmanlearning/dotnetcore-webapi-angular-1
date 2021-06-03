using AutoMapper;
using DotNet_WebAPI_Angular_Data.Models;
using DotNet_WebAPI_Angular_DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet_WebAPI_Angular_APIServices.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MembersDTO, Members>();
            CreateMap<MembersDTO, Members>().ReverseMap();
        }
    }
}
