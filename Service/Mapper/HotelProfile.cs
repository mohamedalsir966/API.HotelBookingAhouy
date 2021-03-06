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

            CreateMap<Hotel, HotelDto>()
                   .ForMember(from => from.FacilitesHotel, to => to.MapFrom(value => value.FacilitesHotel));
            CreateMap<FacilitesHotel, FacilityDto>()
                .ForMember(from => from.Name, to => to.MapFrom(value => value.facilities.Name));

            CreateMap<Hotel, CreateNewHotelCommand>().ReverseMap();


        }
    }
}
 