using AutoMapper;
using Domain.Entities;
using Service.Dto;
using Service.LookupFeaturs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class LookupProfile :Profile
    {
        public LookupProfile()
        {
            CreateMap<Facilities, FacilityDto>();
            CreateMap<Facilities, CreateFacilityCommand>().ReverseMap();
            
        }
    }
}
