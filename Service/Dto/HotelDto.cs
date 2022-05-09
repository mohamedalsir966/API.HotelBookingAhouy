using Domain.Entities;
using Service.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class HotelDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public  List<FacilityDto> FacilitesHotel { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
        public string ImageUrl { get; set; }
    }


    public class HotelResponse : BaseResponse
    {
        public HotelDto Data { get; set; }
    }
    public class HotelsResponse : BaseResponse
    {
        public List<HotelDto> Data { get; set; }
    }
}
