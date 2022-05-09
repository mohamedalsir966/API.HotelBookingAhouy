using AutoMapper;
using Domain.Entities;
using Service.Dto;
using Service.FacilityFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class FacilityHotelProfile : Profile
    {
        public FacilityHotelProfile()
        {
            CreateMap<FacilityHotelDto, FacilitesHotel>();
            CreateMap<FacilitesHotel, CreateHotelFacilityCommand>();
            CreateMap<Facilities, FacilityDto>().ReverseMap();
        }
    }
}
