using Service.Dto.Common;
using System;
using System.Collections.Generic;

namespace Service.Dto
{
    public class FacilityHotelDto
    {
        public Guid HotelId { get; set; }
        public FacilityDto Facility { get; set; }
    }
    public class FacilityHotelRespose : BaseResponse
    {
        public FacilityHotelDto Data { get; set; }
    }

    public class FacilitiesHotelRespose : BaseResponse
    {
        public List<FacilityHotelDto> Data { get; set; }
    }

}
