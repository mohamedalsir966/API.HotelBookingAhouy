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
            CreateMap<FacilitesHotel, FacilityHotelDto>()
                   .ForMember(from => from.Facility, to => to.MapFrom(value => value.facilities));
            CreateMap<FacilitesHotel, CreateHotelFacilityCommand>();
        }
    }
}
