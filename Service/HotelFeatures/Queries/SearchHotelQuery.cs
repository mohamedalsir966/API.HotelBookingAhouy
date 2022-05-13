using AutoMapper;
using MediatR;
using Persistence.Repositories;
using Service.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.HotelFeatures.Queries
{
    public class SearchHotelQuery : IRequest<HotelsResponse>
    {
        public string HotelName { get; }
        public SearchHotelQuery(string hotelName)
        {
            HotelName = hotelName;
        }
    }
    public class SearchHotelQueryHandler : IRequestHandler<SearchHotelQuery, HotelsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelrepository;
        public SearchHotelQueryHandler(IMapper mapper,IHotelRepository hotelrepository)
        {
            _mapper = mapper;
            _hotelrepository = hotelrepository;
        }
        public async Task<HotelsResponse> Handle(SearchHotelQuery request, CancellationToken cancellationToken)
        {
            //need to move
            if (!string.IsNullOrWhiteSpace(request.HotelName))
            {

                return null;
                
            }
                var hotels = await _hotelrepository.GetSearchHotilQuery(request.HotelName);
                if (hotels == null ||hotels.Count==0)
                {
                    return new HotelsResponse
                    {
                        Data = null,
                        StatusCode = 404,
                        Message = "No data found"
                    };
                }
                return new HotelsResponse
                {
                    Data = _mapper.Map<List<HotelDto>>(hotels),
                    StatusCode = 200,
                    Message = "Data found"
                };
           

        }
    }

}
