using AutoMapper;
using Domain.Entities;
using Service.Dto;
using Service.HotelFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Facilities, FacilityDto>();
            CreateMap<FacilitesHotel, FacilityHotelDto>()
                   .ForMember(from => from.Facility, to => to.MapFrom(value => value.facilities));

            CreateMap<Hotel, HotelDto>()
                   .ForMember(from => from.FacilitesHotel, to => to.MapFrom(value => value.FacilitesHotel));
            CreateMap<Hotel, CreateNewHotelCommand>().ReverseMap();
            

        }
    }
}
 